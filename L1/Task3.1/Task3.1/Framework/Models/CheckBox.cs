using OpenQA.Selenium;
using Task3._1.Framework.Models.Base;

namespace Task3._1.Framework.Models
{
    public class CheckBox : BaseElement
    {
        public CheckBox(By locator, string name) : base(locator, name)
        {
        }

        public bool IsChecked()
        {
            return GetElement().Selected;
        }

        public void Check()
        {
            if (!IsChecked())
                Click();
        }

        public void Uncheck()
        {
            if (IsChecked())
                Click();
        }
    }
}
