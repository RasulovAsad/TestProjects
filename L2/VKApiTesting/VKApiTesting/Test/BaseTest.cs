using Aquality.Selenium.Core.Logging;
using Humanizer;
using NUnit.Framework;

namespace VKApiTesting.Test
{
    public abstract class BaseTest
    {
        protected static string ScenarioName
            => TestContext.CurrentContext.Test.Properties.Get("Description")?.ToString()
            ?? TestContext.CurrentContext.Test.Name.Replace("_", string.Empty).Humanize();

        private static Logger Logger => Logger.Instance;

        private static TestContext.ResultAdapter Result => TestContext.CurrentContext.Result;

        [SetUp]
        public void Setup()
        {
            Logger.Info($"Start scenario [{ScenarioName}]");
        }

        [TearDown]
        public virtual void AfterEach()
        {
            LogScenarioResult();
        }

        private void LogScenarioResult()
        {
            Logger.Info($"Scenario [{ScenarioName}] result is {Result.Outcome.Status}!");
            Logger.Info(new string('=', 100));
        }
    }
}
