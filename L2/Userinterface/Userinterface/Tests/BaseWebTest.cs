using Aquality.Selenium.Browsers;
using Userinterface.Configurations;
using NUnit.Framework;

namespace Userinterface.Tests
{
    public abstract class BaseWebTest : BaseTest
    {
        [SetUp]
        public void GoToHomePage()
        {
            AqualityServices.Browser.GoTo(Configuration.StartUrl);
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
