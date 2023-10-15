using OpenQA.Selenium;
using Task3._1.Framework.Models.Base;

namespace Task3._1.PageObjects
{
    public class SamplePage : BaseForm
    {
        public SamplePage(By locator, string name) : base(locator, name) { }
    }
}
