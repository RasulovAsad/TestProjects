using OpenQA.Selenium;
using Serilog;
using Task3._1.Framework.Driver;
using Task3._1.Framework.Models;
using Task3._1.Framework.Models.Base;

namespace Task3._1.PageObjects.MenuForms
{
    public class AlertsForm : BaseForm
    {
        private Button _alertButton = new Button(By.XPath("//button[@id='alertButton']"), "Simple alert");
        private Button _confirmBoxAlertButton = new Button(By.XPath("//button[@id='confirmButton']"), "Confirm box");
        private Button _promptBoxAlertButton = new Button(By.XPath("//button[@id='promtButton']"), "Prompt box");

        private Label _confirmResult = new Label(By.XPath("//span[@id='confirmResult']"), "Confirm result");
        private Label _promptResult = new Label(By.XPath("//span[@id='promptResult']"), "Prompt result");

        public AlertsForm(By locator, string name) : base(locator, name) { }

        public void SimpleAlert()
        {
            Log.Information("User selected simple alert");
            _alertButton.Click();
        }

        public void ConfirmBoxAlert()
        {
            Log.Information("User selected conformation box alert");
            _confirmBoxAlertButton.Click();
        }

        public void PromptBoxAlert()
        {
            Log.Information("User selected prompt box alert");
            _promptBoxAlertButton.Click();
        }

        public string GetConformationBoxResult()
        {
            return _confirmResult.GetText();
        }

        public bool ConformationResultIsDisplayed()
        {
            return _confirmResult.IsDisplayed();
        }

        public string GetPromptBoxResult()
        {
            return _promptResult.GetText();
        }
    }
}
