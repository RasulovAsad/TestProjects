using Aquality.Selenium.Browsers;
using DatabaseTask.Configurations;
using DatabaseTask.Utilities;
using NUnit.Framework;

namespace DatabaseTask.Test
{
    public abstract class BaseWebTest : BaseTest
    {
        [SetUp]
        public void GoToHomePage()
        {
            SavingToDatabaseHelper.SetStartTime(DateTime.Now);
            AqualityServices.Browser.GoTo(Config.StartUrl);
            AqualityServices.Browser.Maximize();
        }

        [TearDown]
        public void CleanUp()
        {
            SavingToDatabaseHelper.SaveTestResult();

            if (AqualityServices.IsBrowserStarted)
            {
                AqualityServices.Browser.Quit();
            }
        }
    }
}
