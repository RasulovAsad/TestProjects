using OpenQA.Selenium;
using Serilog;
using Task3._1.Framework.Models;
using Task3._1.Framework.Models.Base;

namespace Task3._1.PageObjects.MenuForms
{
    public class LinksForm : BaseForm
    {
        private Label _homeLink = new Label(By.XPath("//a[@id='simpleLink']"), "Home link");

        public LinksForm(By locator, string name) : base(locator, name) { }

        public void GoToHomePage()
        {
            Log.Information("User clicked Home link");
            _homeLink.Click();
        }
    }
}
