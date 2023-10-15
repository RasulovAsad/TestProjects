using OpenQA.Selenium;
using Task2._1.Configuration;

namespace Task2._1.Driver
{
    public static class Singleton
    {
        private static WebDriver driver;

        public static WebDriver Driver()
        {
            if (driver is null)
            {
                driver = DriverFactory.createInstance(Utilities.GetConfiguration().Browser);
            }
            return driver;
        }

        public static void CloseDriver()
        {
            driver.Dispose();
            driver = null;
        }
    }
}
