using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace VKApiTesting.Forms.Pages
{
    public class AuthenticationPage : Form
    {
        private ITextBox PasswordInput => ElementFactory.GetTextBox(By.XPath("//input[contains(@class,'vkc__TextField__input') and @type='password']"), "Password input");
        private IButton SubmitButton => ElementFactory.GetButton(By.XPath("//button[contains(@class,'vkuiButton') and @type='submit']"), "Submit button");

        public AuthenticationPage() : base(By.XPath("//div[contains(@class,'vkc__Auth__pageBox')]"), "Authentication page") { }

        public bool PasswordInputIsDisplayed => PasswordInput.State.WaitForDisplayed();
        public void SendKeysPasswordInput(string key) => PasswordInput.SendKeys(key);
        public bool SubmitButtonIsDisplayed => SubmitButton.State.WaitForDisplayed();
        public void ClickSubmitButton() => SubmitButton.Click();
    }
}
