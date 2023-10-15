using OpenQA.Selenium;
using Serilog;
using Task3._1.Framework.Models;
using Task3._1.Framework.Models.Base;

namespace Task3._1.PageObjects
{
    public class HomePage : BaseForm
    {
        private Label _alertsCard = new Label(By.XPath("//*[text()='Alerts, Frame & Windows']/parent::div"), "alertsLink");
        private Label _elementsCard = new Label(By.XPath("//*[text()='Elements']/parent::div"), "elementsLink");


        public HomePage(By locator, string name) : base(locator, name) { }

        public void GoToAlertsPage()
        {
            Log.Information("Navigated to the Alerts, Frame & Windows page");
            _alertsCard.ScrollToElement();
            _alertsCard.Click();
        }
        public void GoToElementsPage()
        {
            Log.Information("Navigated to the Elements page");
            _elementsCard.ScrollToElement();
            _elementsCard.Click();
        }
    }
}
