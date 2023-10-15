using NUnit.Framework;
using VKApiTesting.Forms.Pages;

namespace VKApiTesting.Steps
{
    public static class NewsPageSteps
    {
        private static readonly NewsPage newsPage = new NewsPage();

        public static void NewsPageIsDisplayed()
        {
            Assert.IsTrue(newsPage.State.WaitForDisplayed(), "News page should be displayed");
        }

        public static void CheckThatNewsPageElementsAreDisplayed()
        {
            Assert.IsTrue(newsPage.MyProfileLinkIsDisplayed, "My profile link should be displayed");
        }

        public static void GoToMyProfile()
        {
            newsPage.ClickMyProfileLink();
        }
    }
}
