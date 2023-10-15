using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;
using System.Reflection;

namespace VKApiTesting.Data
{
    public static class UserCredentials
    {
        private static ISettingsFile credentials = new JsonSettingsFile("Resources.TestData.userCredentials.json", Assembly.GetCallingAssembly());

        public static string Login => credentials.GetValue<string>(".login");
        public static string Password => credentials.GetValue<string>(".password");
        public static string AccessToken => credentials.GetValue<string>(".accessToken");
    }
}
