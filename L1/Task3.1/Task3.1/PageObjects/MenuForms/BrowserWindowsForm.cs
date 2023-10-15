using OpenQA.Selenium;
using Serilog;
using Task3._1.Framework.Models;
using Task3._1.Framework.Models.Base;

namespace Task3._1.PageObjects.MenuForms
{
    public class BrowserWindowsForm : BaseForm
    {
        private Button _newTab = new Button(By.XPath("//button[@id='tabButton']"), "New Tab");
        public BrowserWindowsForm(By locator, string name) : base(locator, name) { }

        public void NewTab()
        {
            Log.Information("User clicked New tab button");
            _newTab.Click();
        }
    }
}
