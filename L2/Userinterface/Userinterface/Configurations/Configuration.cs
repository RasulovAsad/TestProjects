using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;
using System.Reflection;

namespace Userinterface.Configurations
{
    public static class Configuration
    {
        private static ISettingsFile config = new JsonSettingsFile("Resources.config.json", Assembly.GetCallingAssembly());

        public static string StartUrl => config.GetValue<string>(".startUrl");
    }
}
