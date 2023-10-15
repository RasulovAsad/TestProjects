using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Task3._1.Framework.Utilities;
using WebDriverManager.DriverConfigs.Impl;

namespace Task3._1.Framework.Driver.Manager
{
    public class FirefoxDriverManager : IFactory
    {
        public WebDriver CreateDriver()
        {
            FirefoxOptions options = new FirefoxOptions();
            if (ConfigManager.GetConfiguration().IsIncognito)
            {
                options.AddArgument("-private");
            }
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            return new FirefoxDriver(options);
        }
    }
}
