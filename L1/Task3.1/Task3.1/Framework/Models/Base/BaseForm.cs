using OpenQA.Selenium;
using Serilog;
using Task3._1.Framework.Driver;
using Task3._1.Framework.Utilities;

namespace Task3._1.Framework.Models.Base
{
    public class BaseForm
    {
        private By _uniqueLocator;
        private string _formName;
        private WebDriver _driver = Browser.GetDriver();
        private WaitsUtil _waits = Browser.GetWaits();

        public BaseForm(By locator, string name)
        {
            _uniqueLocator = locator;
            _formName = name;
        }

        public bool IsOpen()
        {
            Log.Debug($"{_formName} is open");
            return _waits.WaitForDisplayed(_driver.FindElement(_uniqueLocator)) && _waits.WaitForClickable(_driver.FindElement(_uniqueLocator));
        }

        public string GetName()
        {
            return _formName;
        }
    }
}
