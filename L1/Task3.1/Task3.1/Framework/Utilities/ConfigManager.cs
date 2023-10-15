using Microsoft.Extensions.Configuration;

namespace Task3._1.Framework.Utilities
{
    public class ConfigManager
    {
        private static ConfigSettings _config;
        private static string _configPath = @"Data\configsettings.json";

        public static ConfigSettings GetConfiguration()
        {
            _config = new ConfigSettings();
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(_configPath);
            IConfigurationRoot configuration = builder.Build();
            configuration.Bind(_config);
            return _config;
        }
    }
}
