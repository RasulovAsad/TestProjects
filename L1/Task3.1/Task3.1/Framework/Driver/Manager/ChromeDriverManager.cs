using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Task3._1.Framework.Utilities;
using WebDriverManager.DriverConfigs.Impl;

namespace Task3._1.Framework.Driver.Manager
{
    public class ChromeDriverManager : IFactory
    {
        public WebDriver CreateDriver()
        {
            ChromeOptions options = new ChromeOptions();
            if (ConfigManager.GetConfiguration().IsIncognito)
            {
                options.AddArgument("--incognito");
            }
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            return new ChromeDriver(options);
        }
    }
}
