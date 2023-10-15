using OpenQA.Selenium;

namespace Task3._1.Framework.Driver
{
    public interface IFactory
    {
        WebDriver CreateDriver();
    }
}
