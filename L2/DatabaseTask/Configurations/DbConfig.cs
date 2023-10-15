using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;
using System.Reflection;

namespace DatabaseTask.Configurations
{
    public static class DbConfig
    {
        private static ISettingsFile config = new JsonSettingsFile("Resources.dbConfig.json", Assembly.GetCallingAssembly());

        public static string ConnectionString => config.GetValue<string>(".connectionString");
    }
}
