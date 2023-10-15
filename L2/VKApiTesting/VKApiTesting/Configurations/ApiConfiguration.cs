using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;
using System.Reflection;

namespace VKApiTesting.Configurations
{
    public static class ApiConfiguration
    {
        private static ISettingsFile config = new JsonSettingsFile("Resources.apiConfig.json", Assembly.GetCallingAssembly());

        public static string ApiUrl => config.GetValue<string>(".apiUrl");
        public static string ApiVersion => config.GetValue<string>(".apiVersion");
    }
}
