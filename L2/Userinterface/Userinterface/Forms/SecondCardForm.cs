using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Userinterface.Forms
{
    public class SecondCardForm : Form
    {
        private ILink UploadImageLink => ElementFactory.GetLink(By.XPath("//a[contains(@class,'avatar-and-interests__upload-button')]"), "Upload image");
        private ILabel UnselectAllLabel => ElementFactory.GetLabel(By.XPath("//label[@for='interest_unselectall']"), "Unselect All label");
        private ICheckBox UnselectAllCheckBox => ElementFactory.GetCheckBox(By.XPath("//input[@id='interest_unselectall']"), "Unselect All checkbox", Aquality.Selenium.Core.Elements.ElementState.ExistsInAnyState);
        private IList<ICheckBox> Interests => ElementFactory.FindElements<ICheckBox>(By.XPath("//input[@type='checkbox']"), state: Aquality.Selenium.Core.Elements.ElementState.ExistsInAnyState);
        private IButton NextButton => ElementFactory.GetButton(By.XPath("//button[text()='Next']"), "Next button");

        public SecondCardForm() : base(By.XPath("//div[contains(@class,'avatar-and-interests')]"), "Second card")
        {

        }

        public bool IsUploadImageLinkPresent => UploadImageLink.State.IsDisplayed;
        public void ClickUploadImage() => UploadImageLink.Click();
        public bool IsUnselectAllCheckBoxExist => UnselectAllCheckBox.State.IsExist;
        public bool IsUnselectAllLabelPresent => UnselectAllLabel.State.IsDisplayed;
        public bool IsUnselectAllCheckBoxChecked => UnselectAllCheckBox.IsChecked;
        public void CheckUnselectAllCheckBox() => UnselectAllLabel.Click();
        public bool IsInterestsListPresent() => Interests.Count > 0;
        public void CheckInterestByIndex(int index) => Interests[index].JsActions.Click();
        public int GetInterestsCount() => Interests.Count;
        public bool IsInterestChecked(int index) => Interests[index].IsChecked;
        public bool IsNextButtonPresent => NextButton.State.IsDisplayed;
        public void ClickNextButton() => NextButton.Click();
    }
}
