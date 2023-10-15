using OpenQA.Selenium;
using Task3._1.Framework.Driver;
using Task3._1.Framework.Utilities;

namespace Task3._1.Framework.Models.Base
{
    public class BaseElement
    {
        private By _uniqueLocator;
        private string _elementName;
        protected WebDriver _driver = Browser.GetDriver();
        private WaitsUtil _waits = Browser.GetWaits();

        public BaseElement(By locator, string name)
        {
            _uniqueLocator = locator;
            _elementName = name;
        }

        public IWebElement GetElement()
        {
            return _driver.FindElement(_uniqueLocator);
        }

       

        public void ScrollToElement()
        {
            var e = GetElement();
            ((IJavaScriptExecutor)_driver)
            .ExecuteScript("arguments[0].scrollIntoView(true);", e);
        }

        public void Click()
        {
            _waits.WaitForDisplayed(GetElement());
            _waits.WaitForClickable(GetElement());
            GetElement().Click();
        }

        public bool IsDisplayed()
        {
            return _waits.WaitForDisplayed(GetElement());
        }

        public string GetText()
        {
            _waits.WaitForDisplayed(GetElement());
            return GetElement().Text;
        }
    }
}
