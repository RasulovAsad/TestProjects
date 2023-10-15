using OpenQA.Selenium;
using Task3._1.Framework.Models;
using Task3._1.Framework.Models.Base;

namespace Task3._1.PageObjects.MenuForms
{
    public class NestedFramesForm : BaseForm
    {
        private Frame _parentFrame = new Frame(By.XPath("//iframe[@id='frame1']"), "parent frame");
        private Frame _childframe = new Frame(By.XPath("//iframe[@srcdoc='<p>Child Iframe</p>']"), "child Iframe");

        public NestedFramesForm(By locator, string name) : base(locator, name) { }

        public bool ParentFrameIsDisplayed()
        {
            return _parentFrame.IsDisplayed();
        }

        public bool ChildFrameIsDisplayed()
        {
            return _childframe.IsDisplayed();
        }
    }
}
