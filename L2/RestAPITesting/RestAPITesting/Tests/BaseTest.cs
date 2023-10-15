using Humanizer;
using NUnit.Framework;
using RestAPITesting.Logging;
using RestAPITesting.Utilities;
using Serilog;

namespace RestAPITesting.Tests
{
    public class BaseTest
    {
        protected static string ScenarioName
            => TestContext.CurrentContext.Test.Properties.Get("Description")?.ToString()
            ?? TestContext.CurrentContext.Test.Name.Replace("_", string.Empty).Humanize();
        private static TestContext.ResultAdapter Result => TestContext.CurrentContext.Result;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            LoggerManager.LoggerInit();
        }

        [SetUp]
        public void Setup()
        {

            Log.Information($"Start scenario [{ScenarioName}]");
        }

        [TearDown]
        public virtual void AfterEach()
        {
            LogScenarioResult();
        }

        private void LogScenarioResult()
        {
            Log.Information($"Scenario [{ScenarioName}] result is {Result.Outcome.Status}!");
            Log.Information(new string('=', 100));
        }

        protected int GetIdFromJson(string valuePath)
        {
            return JsonHandler.GetIdByPropertyName("TestData/testData.json", valuePath); ;
        }
    }
}
