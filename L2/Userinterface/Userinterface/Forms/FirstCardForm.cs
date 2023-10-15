using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Userinterface.Forms
{
    public class FirstCardForm : Form
    {
        private ICheckBox TermsCheckBox => ElementFactory.GetCheckBox(By.XPath("//input[@id='accept-terms-conditions']"), "Terms checkbox", Aquality.Selenium.Core.Elements.ElementState.ExistsInAnyState);
        private ITextBox PasswordTextBox => ElementFactory.GetTextBox(By.XPath("//input[@placeholder='Choose Password']"), "Password field");
        private ITextBox EmailTextBox => ElementFactory.GetTextBox(By.XPath("//input[@placeholder='Your email']"), "Email field");
        private ITextBox DomainTextBox => ElementFactory.GetTextBox(By.XPath("//input[@placeholder='Domain']"), "Domain field");
        private IList<ILabel> DropDownItems => ElementFactory.FindElements<ILabel>(By.XPath("//div[@class='dropdown__list-item']"), state: Aquality.Selenium.Core.Elements.ElementState.ExistsInAnyState);
        private ILabel DropdownOpener => ElementFactory.GetLabel(By.XPath("//div[contains(@class,'dropdown__opener')]"), "Dropdown opener");
        private ILink NextLink => ElementFactory.GetLink(By.XPath("//a[text()='Next']"), "Next link");

        public FirstCardForm() : base(By.XPath("//div[@class='login-form__container']"), "First card")
        {
        }

        public bool IsTermsCheckBoxExist => TermsCheckBox.State.IsExist;
        public bool IsTermsCheckBoxChecked => TermsCheckBox.IsChecked;
        public void CheckTermsCheckBox() => TermsCheckBox.JsActions.Click();

        public bool IsPasswordTextBoxPresent => PasswordTextBox.State.IsDisplayed;
        public void ClearAndTypePasswordTextBox(string text) => PasswordTextBox.ClearAndType(text);
        public bool IsEmailTextBoxPresent => EmailTextBox.State.IsDisplayed;
        public void ClearAndTypeEmailTextBox(string text) => EmailTextBox.ClearAndType(text);
        public bool IsDomainTextBoxPresent => DomainTextBox.State.IsDisplayed;
        public void ClearAndTypeDomainTextBox(string text) => DomainTextBox.ClearAndType(text);

        public bool IsDropdownOpenerPresent => DropdownOpener.State.IsDisplayed;
        public void ClickDropdownOpener() => DropdownOpener.Click();
        public bool IsDropdownListExist => DropDownItems.Count > 0;
        public void ClickDropdownItemByIndex(int index) => DropDownItems[index].Click();
        public int GetDropdownItemsCount() => DropDownItems.Count;
        public bool IsNextLinkPresent => NextLink.State.IsDisplayed;
        public void ClickNextLink() => NextLink.Click();
    }
}
