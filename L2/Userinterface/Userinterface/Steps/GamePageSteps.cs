using Aquality.Selenium.Browsers;
using NUnit.Framework;
using Userinterface.Forms.Pages;

namespace Userinterface.Steps
{
    public static class GamePageSteps
    {
        private static readonly GamePage gamePage = new GamePage();

        public static void GamePageIsPresent()
        {
            Assert.IsTrue(gamePage.State.WaitForDisplayed(), "Home page should be presented");
        }

        public static void CheckThatGamePageElementsAreDisplayed()
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(gamePage.IsTimerPresent, "Timer should be displayed");
                Assert.IsTrue(gamePage.IsHelpFormPresent, "Help form should be displayed");
                Assert.IsTrue(gamePage.IsSentToBottomButtonPresent, "Send to bottom button should be displayed");
            });
        }

        public static void CheckThatCookiesFormDisplayed()
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(gamePage.IsAccepctCookiesButtonPresent, "Accept cookies button should be displayed");
                Assert.IsTrue(gamePage.IsCookiesFormPresent, "Cookies form should be displayed");
            });
        }

        public static void AcceptCookies()
        {
            AqualityServices.Logger.Info("[STEP] Click 'Not really, no' to accept cookies");
            gamePage.ClickAcceptCookiesButton();
        }

        public static void CheckThatCookiesFormClosed()
        {
            Assert.IsTrue(gamePage.IsCookiesFormClosed, "Cookies form should not be displayed");
        }

        public static void CheckThatTimerIsExpected(string expectedTime)
        {
            Assert.AreEqual(expectedTime, gamePage.GetTimerValue(), $"Timer should be {expectedTime}");
        }

        public static void ClickSendToBottomButton()
        {
            AqualityServices.Logger.Info("[STEP] Click 'Send to bottom' to hide help form");
            gamePage.ClickSendToBottomButton();
        }

        public static void CheckThatHelpFormClosed()
        {
            Assert.IsTrue(gamePage.IsHelpFormClosed(), "Help form should not be displayed");
        }
    }
}
