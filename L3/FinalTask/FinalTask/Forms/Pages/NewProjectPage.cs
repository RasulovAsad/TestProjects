using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace FinalTask.Forms.Pages
{
    public class NewProjectPage : Form
    {
        private ILabel Test(string id) => ElementFactory.GetLabel(By.XPath($"//td/a[contains(@href,'{id}')]"), "Test");

        public NewProjectPage() : base(By.XPath("//div[@id='pie']"), "New proejct page") { }

        public bool IsDisplayed => State.IsDisplayed;
        public bool IsTestPresent(string id) => Test(id).State.WaitForDisplayed();
        public string GetTestName(string id) => Test(id).Text;
    }
}
