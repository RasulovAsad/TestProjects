using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;
using System.Reflection;

namespace DatabaseTask.Data
{
    public static class TestData
    {
        private static ISettingsFile config = new JsonSettingsFile("Resources.testData.json", Assembly.GetCallingAssembly());

        public static string ProjectId => config.GetValue<string>(".projectId");
    }
}
