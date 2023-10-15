using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace Task2._1.Driver.Manager
{
    internal class ChromeDriverManager : IFactory
    {
        public WebDriver CreateDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("incognito");
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            return new ChromeDriver(options);
        }
    }
}
