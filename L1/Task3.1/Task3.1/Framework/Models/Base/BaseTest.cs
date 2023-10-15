using OpenQA.Selenium;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting.Json;
using Task3._1.Framework.Driver;
using Task3._1.Framework.Utilities;

namespace Task3._1.Framework.Models.Base
{
    public class BaseTest
    {
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Browser.GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ConfigManager.GetConfiguration().WaitSeconds);
        }

        [SetUp]
        public void Setup()
        {
            Browser.OpenApplication();
            LoggerManager.LoggerInit();
        }

        [TearDown]
        public void TearDown()
        {
            Log.Information("____________________________________");
            Browser.CloseDriver();

        }
    }
}
