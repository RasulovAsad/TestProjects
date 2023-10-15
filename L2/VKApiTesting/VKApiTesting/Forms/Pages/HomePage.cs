using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace VKApiTesting.Forms.Pages
{
    public class HomePage : Form
    {
        private ITextBox LoginInput => ElementFactory.GetTextBox(By.XPath("//input[@id='index_email']"), "Login input");
        private IButton SubmitButton => ElementFactory.GetButton(By.XPath("//button[contains(@class,'VkIdForm__signInButton')]"), "Submit button");


        public HomePage() : base(By.XPath("//div[contains(@class,'VkIdForm')]"), "Home page") { }

        public bool LoginInputIsDisplayed => LoginInput.State.WaitForDisplayed();
        public void SendKeysLoginInput(string key) => LoginInput.SendKeys(key);
        public bool SubmitButtonIsDisplayed => SubmitButton.State.WaitForDisplayed();
        public void ClickSubmitButton() => SubmitButton.Click();
    }
}
