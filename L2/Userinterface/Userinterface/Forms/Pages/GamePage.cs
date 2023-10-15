using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Userinterface.Forms.Pages
{
    public class GamePage : Form
    {
        private ILabel CookiesForm => ElementFactory.GetLabel(By.XPath("//div[contains(@class,'cookies')]"), "Cookies form");
        private IButton AcceptCookiesButton => CookiesForm.FindChildElement<IButton>(By.XPath("//button[text()='Not really, no']"), "Accept cookies button");
        private ILabel Timer => ElementFactory.GetLabel(By.XPath("//div[contains(@class,'timer')]"), "Timer");
        private ILabel HelpForm => ElementFactory.GetLabel(By.XPath("//div[contains(@class,'help-form')]"), "Help form");
        private IButton SentToBottomButton => ElementFactory.GetButton(By.XPath("//button[contains(@class,'help-form__send-to-bottom-button')]"), "Send to bottom button");

        public GamePage() : base(By.XPath("//div[contains(@class,'game')]"), "Game page")
        {

        }
        
        public bool IsCookiesFormPresent => CookiesForm.State.WaitForDisplayed();
        public bool IsCookiesFormClosed => !CookiesForm.State.IsDisplayed;
        public bool IsAccepctCookiesButtonPresent => AcceptCookiesButton.State.WaitForDisplayed();
        public void ClickAcceptCookiesButton() => AcceptCookiesButton.Click();

        public bool IsTimerPresent => Timer.State.IsDisplayed;
        public string GetTimerValue() => Timer.GetText();

        public bool IsHelpFormPresent => HelpForm.State.IsDisplayed;

        public bool IsHelpFormClosed() => HelpForm.GetAttribute("class").Contains("is-hidden");
        public bool IsSentToBottomButtonPresent => SentToBottomButton.State.IsDisplayed;
        public void ClickSendToBottomButton() => SentToBottomButton.Click();
    }
}
