using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace FinalTask.Forms.Pages
{
    public class NexagePage : Form
    {
        private IList<ILabel> TestsList => ElementFactory.FindElements<ILabel>(By.XPath("//tr[]"), "Tests list");
        private ILabel TestCell(int index) => TestsList[index].FindChildElement<ILabel>(By.XPath("//td[]/a[]"));
        private ILink HomeLink => ElementFactory.GetLink(By.XPath("//a[text()='Home']"), "Home link");

        public NexagePage() : base(By.XPath("//li[text()='Nexage']"), "Nexage project") { }

        public bool IsDisplayed => State.WaitForDisplayed();
        public string GetTestName(int index) => TestCell(index).Text;
        public int GetTestsListCount() => TestsList.Count;
        public void ClickHomeLink() => HomeLink.Click();
    }
}