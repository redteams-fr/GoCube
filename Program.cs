using Newtonsoft.Json;

namespace SmartCube
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }


    public class PlayerGame
    {
        public string[] Algorithm { get; set; }
        public TimeSpan Time { get; set; }
        public string[] Sequence { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsWon { get; set; }
    }

    public class DataRoot
    {
        public List<Algorithm> Data { get; set; }
    }

    public class Algorithm
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        private string? _algorithmData;

        [JsonProperty("algorithmData")]
        public string AlgorithmData
        {
            get => _algorithmData;
            set
            {
                _algorithmData = value;
                AlgorithmDataArray = _algorithmData.Split(' ');
            }
        }

        [JsonIgnore]
        public string[]? AlgorithmDataArray { get; private set; }

        public override string ToString()
        {
            return $"{AlgorithmData}";
        }
    }

}