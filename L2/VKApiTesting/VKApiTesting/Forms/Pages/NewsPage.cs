using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace VKApiTesting.Forms.Pages
{
    public class NewsPage : Form
    {
        private ILink MyProfileLink => ElementFactory.GetLink(By.XPath("//li[@id='l_pr']"), "My Profile link");

        public NewsPage() : base(By.XPath("//div[@id='main_feed']"), "News page") { }

        public bool MyProfileLinkIsDisplayed => MyProfileLink.State.WaitForDisplayed();
        public void ClickMyProfileLink() => MyProfileLink.Click();
    }
}
