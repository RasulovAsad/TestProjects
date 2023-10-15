using Aquality.Selenium.Browsers;
using FinalTask.Configurations;
using FinalTask.Utilities;
using NUnit.Framework;

namespace FinalTask.Tests.Base
{
    public abstract class BaseWebTest : BaseTest
    {
        protected string sessionId;
        protected string startTime;

        [OneTimeSetUp]
        public void SetSessionId()
        {
            sessionId = AqualityServices.Browser.Driver.SessionId.ToString();
        }

        [SetUp]
        public void GoToHomePage()
        {
            startTime = DateTimeUtil.GetFormattedTime(DateTime.Now);
            AqualityServices.Browser.GoTo(Config.StartUrl);
            AqualityServices.Browser.Maximize();
        }

        [TearDown]
        public void CleanUp()
        {
            if (AqualityServices.IsBrowserStarted)
            {
                AqualityServices.Browser.Quit();
            }
        }
    }
}
