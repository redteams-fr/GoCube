using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.Advertisement;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Devices.Enumeration;
using Windows.Storage.Streams;

namespace SmartCube
{
    public partial class Form1 : Form
    {
        private BluetoothLEAdvertisementWatcher bleWatcher;
        private BluetoothLEDevice connectedDevice;
        private Stopwatch _stopwatch;
        private System.Windows.Forms.Timer _timer;

        private int _gameVictory = 0;
        private int _gameCount = 0;
        private List<PlayerGame> _playerGames = new List<PlayerGame>();

        private GattCharacteristic RxCharacteristic;

        private string[] _algorithm = { "U'", "L'", "U", "L", "U", "F", "U'", "F'" };
        private int _algoIndex = 0;

        public delegate void RotationReceivedEventHandler(string rotation);
        public static event RotationReceivedEventHandler RotationReceived;

        public delegate void AlgorithmLoadedEventHandler(Algorithm algorithm);
        public static event AlgorithmLoadedEventHandler AlgorithmLoaded;
        public enum GameState
        {
            Hidden,
            Win,
            Waiting,
            Lost
        }

        public enum MessageType
        {
            MsgRotation = 0x01,
            MsgState = 0x02,
            MsgOrientation = 0x03,
            MsgBattery = 0x05,
            MsgOffLineStats = 0x07,
            MsgCubeType = 0x08,
            Unknown = -1
        }

        public Form1()
        {
            InitializeComponent();
            InitializeBLEWatcher();

            _stopwatch = new Stopwatch();
            _timer = new System.Windows.Forms.Timer();

            _timer.Interval = 10; // Mettre à jour le chronomètre toutes les 10 millisecondes
            _timer.Enabled = true;
            _timer.Tick += Timer_Tick;

            displayGameIHM(false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateDisplayScanning(true);
            UpdateLog($"Waiting for a GoCube beacon ...");
            bleWatcher.Start();
            RotationReceived += RotationReceivedHandler;
            AlgorithmLoaded += AlgorithmLoadedHandler;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (InvokeRequired)
                Invoke(new Action(() => Timer_Tick(sender, e)));
            else
                _labelChrono.Text = _stopwatch.Elapsed.ToString(@"ss\.fff");
        }

        private void InitializeBLEWatcher()
        {
            bleWatcher = new BluetoothLEAdvertisementWatcher
            {
                ScanningMode = BluetoothLEScanningMode.Active
            };

            bleWatcher.Received += BleWatcher_Received;
        }

        private async void BleWatcher_Received(BluetoothLEAdvertisementWatcher sender, BluetoothLEAdvertisementReceivedEventArgs args)
        {
            var deviceName = args.Advertisement.LocalName;

            if (!string.IsNullOrEmpty(deviceName))
            {
                if (deviceName.StartsWith("GoCube"))
                {
                    UpdateDisplayScanning(false);

                    var device = await BluetoothLEDevice.FromBluetoothAddressAsync(args.BluetoothAddress);
                    await ConnectToDeviceAsync(device);

                }
            }
        }

        private void UpdateLog(string message)
        {
            if (InvokeRequired)
                Invoke(new Action(() => UpdateLog(message)));
            else
            {
                richTextBoxReceived.AppendText(message + Environment.NewLine);
                richTextBoxReceived.SelectionStart = richTextBoxReceived.Text.Length;
                richTextBoxReceived.ScrollToCaret();
            }
        }

        private void UpdateDisplayScanning(bool state)
        {
            if (InvokeRequired)
                Invoke(new Action(() => UpdateDisplayScanning(state)));
            else
                _panelScanInProgress.Visible = state;
        }

        private async Task ConnectToDeviceAsync(BluetoothLEDevice device)
        {
            if (device != null)
            {
                connectedDevice = device;
                UpdateLog("Device found : " + connectedDevice.Name);

                try
                {
                    GattDeviceServicesResult result = await device.GetGattServicesAsync();
                    if (result.Status == GattCommunicationStatus.Success)
                    {
                        var services = result.Services;
                        UpdateLog("Paired !");

                        foreach (var service in services)
                        {
                            GattCharacteristicsResult charactiristicResult = await service.GetCharacteristicsAsync();

                            if (charactiristicResult.Status == GattCommunicationStatus.Success)
                            {
                                var characteristics = charactiristicResult.Characteristics;
                                foreach (var characteristic in characteristics)
                                {
                                    //UpdateLog($"characteristic: {characteristic}");
                                    GattCharacteristicProperties properties = characteristic.CharacteristicProperties;
                                    if (properties.HasFlag(GattCharacteristicProperties.Notify))
                                    {
                                        UpdateLog($"Subscribe to message ...");
                                        GattCommunicationStatus status = await characteristic.WriteClientCharacteristicConfigurationDescriptorAsync(
                                            GattClientCharacteristicConfigurationDescriptorValue.Notify);
                                        if (status == GattCommunicationStatus.Success)
                                            characteristic.ValueChanged += Characteristic_ValueChanged;

                                        startGame();
                                    }

                                    if (characteristic.Uuid == new Guid("6e400002-b5a3-f393-e0a9-e50e24dcca9e"))
                                    {
                                        UpdateLog("Found Uuid for sending request");
                                        RxCharacteristic = characteristic;
                                    }
                                }
                            }
                        }
                        bleWatcher.Stop();
                    }
                }
                catch (Exception ex)
                {
                    UpdateLog("Failed to connect, wait for next beacon ... ");
                }

            }
        }

        private void AlgorithmLoadedHandler(Algorithm algorithm)
        {
            UpdateLog($"New algorithm loaded : {algorithm}");
            _algorithm = algorithm.AlgorithmDataArray;
            UpdateLabels();
        }

        private void Characteristic_ValueChanged(GattCharacteristic sender, GattValueChangedEventArgs args)
        {
            var reader = DataReader.FromBuffer(args.CharacteristicValue);
            byte[] input = new byte[reader.UnconsumedBufferLength];
            reader.ReadBytes(input);
            ProcessMessage(input);
        }

        private bool IsChecksumValid(byte[] rawData, int length)
        {
            int checksum = rawData[length - 1];
            int calculatedChecksum = 0;
            for (int i = 0; i < length - 1; i++)
            {
                calculatedChecksum += rawData[i];
            }
            calculatedChecksum %= 0x100;

            return checksum == calculatedChecksum;
        }

        private MessageType GetMessageType(byte[] rawData)
        {
            int type = rawData[2];
            return Enum.IsDefined(typeof(MessageType), type) ? (MessageType)type : MessageType.Unknown;
        }

        private void ProcessMessage(byte[] rawData)
        {
            int prefix = rawData[0];
            int length = rawData[1];
            // Invalid message format
            if (prefix != 0x2A || rawData[length] != 0x0D || rawData[length + 1] != 0x0A)
                return;

            // Invalid checksum
            if (!IsChecksumValid(rawData, length))
                return;

            byte[] message = new byte[length - 4];
            Array.Copy(rawData, 3, message, 0, length - 4);

            MessageType messageType = GetMessageType(rawData);

            switch (messageType)
            {
                case MessageType.MsgRotation:
                    ProcessRotation(message);
                    break;
                case MessageType.MsgState:
                    // ProcessState
                    break;
                case MessageType.MsgOrientation:
                    // ProcessOrientation
                    break;
                case MessageType.MsgBattery:
                    ProcessBatteryLevel(message);
                    break;
                case MessageType.MsgOffLineStats:
                    //ProcessOffLineStats
                    break;
                case MessageType.MsgCubeType:
                    //ProcessCubeType
                    break;
                default:
                    UpdateLog("Unknown message type.");
                    break;
            }
        }

        private void ProcessBatteryLevel(byte[] message)
        {
            UpdateLog($"Receive battery message");
            int batteryLevel = message[0];
            UpdateBatteryStatus(batteryLevel);
        }


        private void UpdateBatteryStatus(int batteryLevel)
        {
            if (InvokeRequired)
                Invoke(new Action(() => UpdateBatteryStatus(batteryLevel)));
            else
            {
                _labelbatteryLevel.Visible = true;
                _labelbatteryLevel.Text = $"Battery Level: {batteryLevel}%";
            }
        }

        private void ProcessRotation(byte[] message)
        {
            Dictionary<byte, string> rotationMapping = new Dictionary<byte, string>
            {
                {0x00, "B"},
                {0x01, "B'"},
                {0x02, "F"},
                {0x03, "F'"},
                {0x04, "D"},
                {0x05, "D'"},
                {0x06, "U"},
                {0x07, "U'"},
                {0x08, "L"},
                {0x09, "L'"},
                {0x0A, "R"},
                {0x0B, "R'"}
            };

            for (int i = 0; i < message.Length; i += 2)
            {
                byte faceRotation = message[i];
                string rotationNotation = "";

                if (rotationMapping.TryGetValue(faceRotation, out rotationNotation))
                    RotationReceived?.Invoke(rotationNotation);
                else
                    RotationReceived?.Invoke("Unknown");
            }
        }

        List<string> playerMoves = new List<string>();

        private void RotationReceivedHandler(string rotation)
        {
            UpdateLog($"Received rotation {rotation}");

            if (_algorithm[_algoIndex] == rotation)
            {
                _algoIndex++;
                if (_algoIndex == 1)
                {
                    playerMoves.Clear();
                    _gameCount++;
                    _stopwatch.Restart();
                    UpdateGameStateLabel(GameState.Hidden);
                    UpdateLog($"Start a new game");
                }

                if (_algoIndex == _algorithm.Length)
                {
                    _algoIndex = 0;
                    _gameVictory++;
                    AddPlayerGame(true, playerMoves.ToArray(), _algorithm);
                    UpdateGameStateLabel(GameState.Win);
                    UpdateLog($"Success - adding time : {_stopwatch.Elapsed:ss\\.fff}");
                    AddGameTime($"{_stopwatch.Elapsed:ss\\.fff}");
                    _stopwatch.Reset();
                }
                playerMoves.Add(rotation);
            }
            else
            {
                playerMoves.Add(rotation);
                string information = $"{rotation} instead {_algorithm[_algoIndex]}";
                string playerSequence = string.Join(" ", playerMoves);
                UpdateGameStateLabel(GameState.Lost, information);
                UpdateLog($"Failed - Player's sequence: {playerSequence}");
                _algoIndex = 0;
                _stopwatch.Reset();
                AddPlayerGame(false, playerMoves.ToArray(), _algorithm);
            }

            UpdateLabels();
        }

        private void AddPlayerGame(bool isWon, string[] playerSequence, string[] algorithm)
        {
            _playerGames.Add(new PlayerGame
            {
                Algorithm = algorithm,
                Time = _stopwatch.Elapsed,
                Sequence = playerSequence,
                Timestamp = DateTime.Now,
                IsWon = isWon
            });
        }

        private void startGame()
        {
            RequestBatteryLevelAsync();
            displayGameIHM(true);
            UpdateGameStateLabel(GameState.Waiting);
            UpdateLabels();
        }

        private void displayGameIHM(bool state)
        {
            if (InvokeRequired)
                Invoke(new Action(() => displayGameIHM(state)));
            else
            {
                _panelGameCounters.Visible = state;
                _labelChrono.Visible = state;
                _labelAlgoPlayer.Visible = state;
                _labelAlgoModel.Visible = state;
                if (!state)
                    UpdateGameStateLabel(GameState.Hidden);
            }
        }

        private void UpdateLabels()
        {
            if (InvokeRequired)
                Invoke(new Action(() => UpdateLabels()));
            else
            {
                _labelAlgoModel.Text = string.Join(" ", _algorithm);
                _labelAlgoPlayer.Text = string.Join(" ", _algorithm, 0, _algoIndex);
            }
        }

        private void UpdateGameStateLabel(GameState gameState, string information = "")
        {
            if (InvokeRequired)
                Invoke(new Action(() => UpdateGameStateLabel(gameState, information)));
            else
            {
                _labelGameVictory.Text = _gameVictory.ToString();
                _labelGameCount.Text = _gameCount.ToString();

                switch (gameState)
                {
                    case GameState.Win:
                        _labelGameState.Text = "Success " + information;
                        _labelGameState.ForeColor = Color.ForestGreen;
                        _labelGameState.Visible = true;
                        break;

                    case GameState.Lost:
                        _labelGameState.Text = "Failed " + information;
                        _labelGameState.ForeColor = Color.DarkRed;
                        _labelGameState.Visible = true;
                        break;

                    case GameState.Waiting:
                        _labelGameState.Text = "Waiting for first move";
                        _labelGameState.ForeColor = Color.White;
                        _labelGameState.Visible = true;
                        break;

                    case GameState.Hidden:
                    default:
                        _labelGameState.Visible = false;
                        break;
                }
            }
        }


        private void AddGameTime(String _time)
        {
            if (InvokeRequired)
                Invoke(new Action(() => AddGameTime(_time)));
            else
            {
                _gameHistory.Visible = true;
                _gameHistory.Items.Insert(0, _time);
            }
        }

        private async Task RequestBatteryLevelAsync()
        {
            if (RxCharacteristic != null)
            {
                UpdateLog("Request battery level.");
                byte[] request = { 0x32 }; // GetBattery request
                var writer = new DataWriter();
                writer.WriteBytes(request);
                GattCommunicationStatus status = await RxCharacteristic.WriteValueAsync(writer.DetachBuffer());
                if (status == GattCommunicationStatus.Success)
                {
                    return;
                }
            }
            UpdateLog("Failed to request battery level.");
        }

        private void algorithmButton_Click(object sender, EventArgs e)
        {
            FormAlgoSelector formAlgoSelector = new FormAlgoSelector(AlgorithmLoaded);
            formAlgoSelector.ShowDialog(this);
        }


    }

}