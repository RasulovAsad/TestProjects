using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Task2._1.Configuration
{
    public static class Utilities
    {

        public static ConfigSettings config;
        private static string _configPath = Path.Combine(Directory.GetParent(@"..\..\..\").FullName, @"Data\configsettings.json");
        private static string _testdataPath = Path.Combine(Directory.GetParent(@"..\..\..\").FullName, @"Data\testdata.json");

        public static ConfigSettings GetConfiguration()
        {
            config = new ConfigSettings();
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(_configPath);
            IConfigurationRoot configuration = builder.Build();
            configuration.Bind(config);
            return config;
        }

        public static Dictionary<string, dynamic> GetTestData()
        {
            Dictionary<string, dynamic> source;
            using (StreamReader reader = new StreamReader(_testdataPath))
            {
                string json = reader.ReadToEnd();
                source = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(json);
            }
            return source;
        }
    }
}
