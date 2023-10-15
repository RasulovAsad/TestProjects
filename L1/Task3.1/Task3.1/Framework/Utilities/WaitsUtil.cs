using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Task3._1.Framework.Driver;
using Task3._1.Framework.Models.Base;

namespace Task3._1.Framework.Utilities
{
    public class WaitsUtil
    {
        private static int _timeOutInSeconds = ConfigManager.GetConfiguration().WaitSeconds;
        private WebDriverWait _webDriverWait;

        public WaitsUtil(int timeOutInSeconds)
        {
            _webDriverWait = new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(timeOutInSeconds));
            _timeOutInSeconds = timeOutInSeconds;
        }

        public bool WaitForDisplayed(IWebElement elem)
        {
            return _webDriverWait.Until(condition => { return elem.Displayed; });
        }

        public bool WaitForClickable(IWebElement elem)
        {
            return _webDriverWait.Until(condition => { return elem.Enabled; });
        }
    }
}
