using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;
using System.Reflection;

namespace VKApiTesting.Configurations
{
    public class Configuration
    {
        private static ISettingsFile config = new JsonSettingsFile("Resources.config.json", Assembly.GetCallingAssembly());

        public static string StartUrl => config.GetValue<string>(".startUrl");
        public static int UserIdLength => config.GetValue<int>(".userIdLength");
    }
}
