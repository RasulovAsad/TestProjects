using OpenQA.Selenium;
using Serilog;
using Task3._1.Framework.Models.Base;

namespace Task3._1.Framework.Models
{
    public class TextBox : BaseElement
    {
        public TextBox(By locator, string name) : base(locator, name)
        {
        }

        public void SendText(string text)
        {
            Log.Debug($"\"{text}\" is entered in the text field");
            if (IsDisplayed())
                GetElement().SendKeys(text);
        }

        public void Clear()
        {
            if (IsDisplayed())
                GetElement().Clear();
        }
    }
}
