using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace Task2._1.Driver.Manager
{
    internal class FirefoxDriverManager : IFactory
    {
        public WebDriver CreateDriver()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("incognito");
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            return new FirefoxDriver(options);
        }
    }
}
