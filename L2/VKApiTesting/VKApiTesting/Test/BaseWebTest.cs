using Aquality.Selenium.Browsers;
using NUnit.Framework;
using VKApiTesting.Configurations;

namespace VKApiTesting.Test
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
