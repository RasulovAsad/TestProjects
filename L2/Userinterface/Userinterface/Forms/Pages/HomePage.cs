using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Userinterface.Forms.Pages
{
    public class HomePage : Form
    {
        private ILink StartLink => ElementFactory.GetLink(By.XPath("//a[contains(@class,'start__link')]"), "Start link");

        public HomePage() : base(By.XPath("//div[contains(@class,'start')]"), "Home page")
        {

        }

        public bool IsStartLinkEXist => StartLink.State.IsExist;

        public void ClickStartLink() => StartLink.Click();
    }
}
