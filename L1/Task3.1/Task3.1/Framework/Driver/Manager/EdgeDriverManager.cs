using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using Task3._1.Framework.Utilities;
using WebDriverManager.DriverConfigs.Impl;

namespace Task3._1.Framework.Driver.Manager
{
    public class EdgeDriverManager : IFactory
    {
        public WebDriver CreateDriver()
        {
            EdgeOptions options = new EdgeOptions();
            if (ConfigManager.GetConfiguration().IsIncognito)
            {
                options.AddArgument("incognito");
            }
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            return new EdgeDriver(options);
        }
    }
}
