using Aquality.Selenium.Browsers;
using NUnit.Framework;
using Userinterface.Forms;
using Userinterface.Utilities;

namespace Userinterface.Steps
{
    public static class FirstCardSteps
    {
        private static readonly FirstCardForm firstCard = new FirstCardForm();

        public static void FirstCardIsPresent()
        {
            Assert.IsTrue(firstCard.State.WaitForDisplayed(), "First card should be presented");
        }

        public static void CheckThatFirstCardElementsAreDisplayed()
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(firstCard.IsTermsCheckBoxExist, "Terms checkBox should be exist");
                Assert.IsTrue(firstCard.IsPasswordTextBoxPresent, "Password field should be displayed");
                Assert.IsTrue(firstCard.IsEmailTextBoxPresent, "Email field should be displayed");
                Assert.IsTrue(firstCard.IsDomainTextBoxPresent, "Domain field should be displayed");
                Assert.IsTrue(firstCard.IsDropdownListExist, "Dropdown items should be exist");
            });
        }

        public static void CheckTermCheckBox()
        {
            AqualityServices.Logger.Info("[STEP] Click 'I do not accept the Terms & Conditions' checkbox");
            firstCard.CheckTermsCheckBox();
        }

        public static void CheckTermCheckBoxIsCheckedOrNot(bool isChecked = false)
        {
            var expectedStatus = isChecked ? "checked" : "not checked";
            Assert.AreEqual(firstCard.IsTermsCheckBoxChecked, isChecked, $"Term CheckBox should be {expectedStatus}");
        }

        public static void FillAllTextFieldsInFirstCard(string email, string password, string domain)
        {
            AqualityServices.Logger.Info("[STEP] Enter password, email and domain");
            firstCard.ClearAndTypeEmailTextBox(email);
            firstCard.ClearAndTypePasswordTextBox(password);
            firstCard.ClearAndTypeDomainTextBox(domain);
        }

        public static void SelectDropdownItem(int index)
        {
            AqualityServices.Logger.Info("[STEP] Select an option from dropdown list");
            firstCard.ClickDropdownOpener();
            firstCard.ClickDropdownItemByIndex(index);
        }

        public static void ClickNextLink()
        {
            AqualityServices.Logger.Info("[STEP] Click 'Next' button to submit the form and navigate to the next card");
            firstCard.ClickNextLink();
        }

        public static int GetDropdownItemsCount()
        {
            return firstCard.GetDropdownItemsCount();
        }
    }
}
