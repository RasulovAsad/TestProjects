using OpenQA.Selenium;
using Serilog;
using Task3._1.Framework.Utilities;

namespace Task3._1.Framework.Driver
{
    public static class Browser
    {
        private static WebDriver _driver;
        private static WaitsUtil _waits;

        public static WebDriver GetDriver()
        {
            if (_driver is null)
            {
                _driver = DriverFactory.CreateInstance(ConfigManager.GetConfiguration().Browser);
            }
            return _driver;
        }

        public static void SwitchToTab(int id)
        {
            Log.Debug("Switched tab");
            _driver.SwitchTo().Window(_driver.WindowHandles[id]);
        }

        public static void SwitchToFrame(string frame)
        {
            Log.Debug("Switched frame");
            _driver.SwitchTo().Frame(frame);
        }

        public static void SwitchToParentFrame()
        {
            Log.Debug("Switched to parent frame");
            _driver.SwitchTo().ParentFrame();
        }

        public static void CloseTab()
        {
            Log.Debug("Closed tab");
            _driver.Close();
        }

        public static void CloseDriver()
        {
            _driver?.Dispose();
            _driver = null;
        }

        public static void OpenApplication()
        {
            GetDriver().Manage().Window.Maximize();
            GetDriver().Navigate().GoToUrl(ConfigManager.GetConfiguration().AppUrl);
        }

        public static WaitsUtil GetWaits()
        {
            if (_waits is null)
            {
                _waits = new WaitsUtil(ConfigManager.GetConfiguration().WaitSeconds);
            }
            return _waits;
        }
    }
}
