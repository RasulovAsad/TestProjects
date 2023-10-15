using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;
using System.Reflection;

namespace FinalTask.Configurations
{
    public static class Config
    {
        private static ISettingsFile config = new JsonSettingsFile("Resources.config.json", Assembly.GetCallingAssembly());

        public static string StartUrl => config.GetValue<string>(".startUrl");
        public static string ApiUrl => config.GetValue<string>(".apiUrl");
        public static int MaxApiRequestTries => config.GetValue<int>(".maxApiRequestTries");
    }
}
