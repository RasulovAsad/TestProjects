using OpenQA.Selenium;
using Task3._1.Framework.Models.Base;

namespace Task3._1.Framework.Models
{
    public class Button : BaseElement
    {
        public Button(By locator, string name) : base(locator, name)
        {
        }
    }
}
