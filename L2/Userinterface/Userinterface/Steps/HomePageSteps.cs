using Aquality.Selenium.Browsers;
using NUnit.Framework;
using Userinterface.Forms.Pages;

namespace Userinterface.Steps
{
    public static class HomePageSteps
    {
        private static readonly HomePage homePage = new HomePage();

        public static void HomePageIsPresent()
        {
            Assert.IsTrue(homePage.State.WaitForDisplayed(), "Home page should be presented");
        }
        public static void ClickStartLink()
        {
            AqualityServices.Logger.Info("[STEP] Click the link (in text 'Please click HERE to GO to the next page') to navigate the next page");
            homePage.ClickStartLink();
        }

        public static void StartLinkIsPresent()
        {
            Assert.IsTrue(homePage.IsStartLinkEXist, "Start link should be present");
        }
    }
}
