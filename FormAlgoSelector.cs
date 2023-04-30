using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SmartCube.Form1;

namespace SmartCube
{
    public partial class FormAlgoSelector : Form
    {
        private AlgorithmLoadedEventHandler algorithmLoadedEventHandler;
        public FormAlgoSelector()
        {
            InitializeComponent();
        }

        public FormAlgoSelector(AlgorithmLoadedEventHandler algorithmLoadedEventHandler)
        {
            InitializeComponent();
            this.algorithmLoadedEventHandler = algorithmLoadedEventHandler;
            LoadAndDisplayData();
        }

        private void _listBoxAlgorithms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_listBoxAlgorithms.SelectedIndex != -1)
            {

                Algorithm selectedAlgorithm = (Algorithm)_listBoxAlgorithms.SelectedItem;

                algorithmLoadedEventHandler?.Invoke(selectedAlgorithm);
            }
        }

        private void FormAlgoSelector_Load(object sender, EventArgs e)
        {

        }

        private void LoadAndDisplayData(bool forceBrowse = false)
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            try
            {
                string filePath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    "algorithms.json");
                if (forceBrowse || !File.Exists(filePath))
                {
                    filePath = ShowOpenFileDialog(currentDirectory);
                    if (string.IsNullOrEmpty(filePath))
                    {
                        return;
                    }
                }

                List<Algorithm> algorithms = LoadAlgorithmData(filePath);
                _listBoxAlgorithms.Items.Clear();
                _listBoxAlgorithms.Items.AddRange(algorithms.ToArray());
            }
            catch (Exception ex)
            {

            }
        }


        private List<Algorithm> LoadAlgorithmData(string filePath)
        {
            string jsonContent = File.ReadAllText(filePath);
            DataRoot dataRoot = JsonConvert.DeserializeObject<DataRoot>(jsonContent);


            return dataRoot.Data;
        }

        private string ShowOpenFileDialog(string defaultPath)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Path.GetDirectoryName(defaultPath);
                openFileDialog.FileName = Path.GetFileName(defaultPath);
                openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return openFileDialog.FileName;
                }
            }
            return null;
        }

        private void _buttonLoad_Click(object sender, EventArgs e)
        {
            LoadAndDisplayData(true);
        }
    }


}
