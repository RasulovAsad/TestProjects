using Aquality.Selenium.Core.Logging;
using DatabaseTask.Configurations;
using DatabaseTask.Utilities;
using Humanizer;
using NUnit.Framework;

namespace DatabaseTask.Test
{
    public abstract class BaseTest
    {
        protected static string ScenarioName
            => TestContext.CurrentContext.Test.Properties.Get("Description")?.ToString()
            ?? TestContext.CurrentContext.Test.Name.Replace("_", string.Empty).Humanize();

        private static Logger Logger => Logger.Instance;

        private static TestContext.ResultAdapter Result => TestContext.CurrentContext.Result;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            DatabaseUtil.SetConnectionSettings(DbConfig.ConnectionString);
            DatabaseUtil.OpenConnection();
            SavingToDatabaseHelper.SaveSession();
        }

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

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            DatabaseUtil.CloseConnection();
        }

        private void LogScenarioResult()
        {
            Logger.Info($"Scenario [{ScenarioName}] result is {Result.Outcome.Status}!");
            Logger.Info(new string('=', 100));
        }
    }
}
