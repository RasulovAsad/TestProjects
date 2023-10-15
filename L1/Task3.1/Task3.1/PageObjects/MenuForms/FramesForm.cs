using OpenQA.Selenium;
using Task3._1.Framework.Models;
using Task3._1.Framework.Models.Base;

namespace Task3._1.PageObjects.MenuForms
{
    public class FramesForm : BaseForm
    {
        private Frame _frame1 = new Frame(By.XPath("//iframe[@id='frame1']"), "First frame");
        private Frame _frame2 = new Frame(By.XPath("//iframe[@id='frame2']"), "Second frame");
        private Label _sampleHeading = new Label(By.XPath("//*[@id='sampleHeading']"), "Sample heading");

        public FramesForm(By locator, string name) : base(locator, name) { }

        public string GetSampleHeadingText()
        {
            return _sampleHeading.GetText();
        }
    }
}
