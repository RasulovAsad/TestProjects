using OpenQA.Selenium;
using Task2._1.Driver.Manager;

namespace Task2._1.Driver
{
    internal class DriverFactory
    {
        public static WebDriver createInstance(String browser)
        {
            WebDriver driver;
            

            switch (browser.ToUpper())
            {

                case "CHROME":
                    driver = new ChromeDriverManager().CreateDriver();
                    break;
                case "FIREFOX":
                    driver = new FirefoxDriverManager().CreateDriver();
                    break;
                case "EDGE":
                    driver = new EdgeDriverManager().CreateDriver();
                    break;
                default:
                    throw new NotSupportedException($"{browser} browser is not supported.");
            }
            return driver;
        }
    }
}
