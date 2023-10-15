using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;
using System.Reflection;

namespace FinalTask.Data
{
    public static class TestData
    {
        private static ISettingsFile data = new JsonSettingsFile("Resources.testData.json", Assembly.GetCallingAssembly());

        public static string Variant => data.GetValue<string>(".variant");
        public static string ProjectName => data.GetValue<string>(".projectName");
        public static string NewProjectName => data.GetValue<string>(".newProjectName");
    }
}
