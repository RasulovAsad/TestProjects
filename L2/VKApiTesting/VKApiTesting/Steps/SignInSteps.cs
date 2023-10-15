using NUnit.Framework;
using VKApiTesting.Forms.Pages;

namespace VKApiTesting.Steps
{
    public static class SignInSteps
    {
        private static readonly HomePage homePage = new HomePage();
        private static readonly AuthenticationPage authenticationPage = new AuthenticationPage();

        public static void SignIn(string login, string password)
        {
            Assert.IsTrue(homePage.State.WaitForDisplayed(), "Home page should be displayed");
            Assert.IsTrue(homePage.LoginInputIsDisplayed, "Login input should be displayed");
            Assert.IsTrue(homePage.SubmitButtonIsDisplayed, "Submit button should be displayed");
            homePage.SendKeysLoginInput(login);
            homePage.ClickSubmitButton();

            Assert.IsTrue(authenticationPage.State.WaitForDisplayed(), "Authentication page should be displayed");
            Assert.IsTrue(authenticationPage.PasswordInputIsDisplayed, "Password input should be displayed");
            Assert.IsTrue(authenticationPage.SubmitButtonIsDisplayed, "Submit button should be displayed");
            authenticationPage.SendKeysPasswordInput(password);
            authenticationPage.ClickSubmitButton();
        }
    }
}
