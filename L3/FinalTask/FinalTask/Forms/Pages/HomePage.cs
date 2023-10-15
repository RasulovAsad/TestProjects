using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace FinalTask.Forms.Pages
{
    public class HomePage : Form
    {
        private ILabel VariantLabel => ElementFactory.GetLabel(By.XPath("//p[contains(@class,'footer-text')]/span"), "Variant number");
        private ILink ProjectLink(string projectName) => ElementFactory.GetLink(By.XPath($"//a[@class='list-group-item' and text()='{projectName}']"), "Nexage link");
        private IButton AddButton => ElementFactory.GetButton(By.XPath("//a[@href='addProject']"), "Add button");

        public HomePage() : base(By.XPath("//div[contains(@class,'list-group')]"), "Home page") { }

        public bool IsDisplayed => State.WaitForDisplayed();
        public bool IsVariantLabelDisplayed => VariantLabel.State.IsDisplayed;
        public string GetVariantLabelText() => VariantLabel.Text;
        public bool IsProjectLinkPresent(string projectName) => ProjectLink(projectName).State.IsDisplayed;
        public string GetProjectLinkHref(string projectName) => ProjectLink(projectName).Href;
        public void ClickProjectLink(string projectName) => ProjectLink(projectName).Click();
        public bool IsAddButtonPresent => AddButton.State.IsDisplayed;
        public void ClickAddButton() => AddButton.Click();
    }
}
