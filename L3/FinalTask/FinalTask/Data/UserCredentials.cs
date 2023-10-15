using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;
using System.Reflection;

namespace FinalTask.Data
{
    public static class UserCredentials
    {
        private static ISettingsFile data = new JsonSettingsFile("Resources.userCredentials.json", Assembly.GetCallingAssembly());

        public static string Login => data.GetValue<string>(".login");
        public static string Password => data.GetValue<string>(".password");
    }
}
