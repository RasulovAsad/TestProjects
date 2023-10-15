using DatabaseTask.Forms.Pages;
using NUnit.Framework;

namespace DatabaseTask.Test
{
    public class Tests : BaseWebTest
    {
        [Test(Description = "TC_1: Verify that contact us page is working")]
        public void VerifyThatContactUsPageIsWorking()
        {
            MainPage mainPage = new MainPage();
            Assert.IsTrue(mainPage.PageIsPresent, "Main page should be displayed");
            Assert.IsTrue(mainPage.ContactUsButtonIsPresent, "Contact us button should be displayed");
            mainPage.ClickContactUsButton();
            ContactUsPage contactUsPage = new ContactUsPage();
            Assert.IsTrue(contactUsPage.PageIsPresent, "Contact us page should be displayed");
        }

        [Test(Description = "TC_2: Accept cookies")]
        public void AcceptCookies()
        {
            MainPage mainPage = new MainPage();
            Assert.IsTrue(mainPage.PageIsPresent, "Main page should be displayed");
            Assert.IsTrue(mainPage.AcceptCookiesButtonIsPresent, "Accept cookies button should be displayed");
            mainPage.ClickAcceptCookies();
            Assert.IsFalse(mainPage.AcceptCookiesButtonIsPresent, "Accept cookies button should not be displayed");
        }
    }
}