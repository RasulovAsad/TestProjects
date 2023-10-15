using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace FinalTask.Forms
{
    public class AddProjectForm : Form
    {
        private ITextBox ProjectName => ElementFactory.GetTextBox(By.XPath("//input[@id='projectName']"), "Project name textbox");
        private IButton Submit => ElementFactory.GetButton(By.XPath("//button[@type='submit']"), "Submit button");

        public AddProjectForm() : base(By.XPath("//input[@name='projectName']"), "Add project form") { }

        public void TypeProjectName(string text) => ProjectName.SendKeys(text);
        public void ClickSubmit() => Submit.Click();
    }
}
