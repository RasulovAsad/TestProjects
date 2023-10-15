using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using WebDriverManager.DriverConfigs.Impl;

namespace Task2._1.Driver.Manager
{
    internal class EdgeDriverManager : IFactory
    {
        public WebDriver CreateDriver()
        {
            EdgeOptions options = new EdgeOptions();
            options.AddArgument("incognito");
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            return new EdgeDriver(options);
        }
    }
}
