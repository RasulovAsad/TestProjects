using OpenQA.Selenium;
using Task3._1.Framework.Driver.Manager;

namespace Task3._1.Framework.Driver
{
    public class DriverFactory
    {
        public static WebDriver CreateInstance(string browser)
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
