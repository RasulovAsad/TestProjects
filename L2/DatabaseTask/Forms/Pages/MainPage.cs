using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace DatabaseTask.Forms.Pages
{
    public class MainPage : Form
    {
        private IButton ContactUsButton => ElementFactory.GetButton(By.XPath("//a[@class='btn']"), "Contact us button");
        private IButton AcceptCookies => ElementFactory.GetButton(By.XPath("//div[@class='cookies__button']/button[@class='btn']"), "Accept cookies");

        public MainPage() : base(By.XPath("//body[contains(@class,'page-template-page-main')]"), "Main page") { }

        public bool PageIsPresent => State.IsDisplayed;
        public bool ContactUsButtonIsPresent => ContactUsButton.State.IsDisplayed;
        public void ClickContactUsButton() => ContactUsButton.Click();
        public bool AcceptCookiesButtonIsPresent => AcceptCookies.State.IsDisplayed;
        public void ClickAcceptCookies() => AcceptCookies.Click();
    }
}
