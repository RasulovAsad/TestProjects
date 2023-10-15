using Aquality.Selenium.Browsers;
using NUnit.Framework;
using Userinterface.Forms;
using Userinterface.TestingData;
using Userinterface.Utilities;

namespace Userinterface.Steps
{
    public static class SecondCardSteps
    {
        private static readonly SecondCardForm secondCard = new SecondCardForm();

        public static void SecondCardIsPresent()
        {
            Assert.IsTrue(secondCard.State.WaitForDisplayed(), "Second card should be presented");
        }

        public static void CheckThatSecondCardElementsAreDisplayed()
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(secondCard.IsUploadImageLinkPresent, "Upload image link should be displayed");
                Assert.IsTrue(secondCard.IsUnselectAllCheckBoxExist, "Unselect all checkBox should be exist");
                Assert.IsTrue(secondCard.IsUnselectAllLabelPresent, "Unselect all label should be displayed");
                Assert.IsTrue(secondCard.IsInterestsListPresent(), "Interests labels should be displayed");
                Assert.IsTrue(secondCard.IsNextButtonPresent, "Next button should be displayed");
            });
        }

        public static void ClickUploadImage()
        {
            AqualityServices.Logger.Info("[STEP] Click the link in the text (To complete your profile, please upload any image.) to upload an image");
            secondCard.ClickUploadImage();
        }

        public static void UploadImage(string imageName)
        {
            AqualityServices.Logger.Info("[STEP] Upload an image");
            FileUploadUtils.UploadImage(imageName);
        }

        public static void CheckUnselectAllCheckBoxIsCheckedOrNot(bool isChecked = false)
        {
            var expectedStatus = isChecked ? "checked" : "not checked";
            Assert.AreEqual(secondCard.IsUnselectAllCheckBoxChecked, isChecked, $"Unselect all CheckBox should be {expectedStatus}");
        }

        public static void CheckUnselectAllCheckBox()
        {
            AqualityServices.Logger.Info("[STEP] Click 'Unselect All' checkbox to unselect interests");
            secondCard.CheckUnselectAllCheckBox();
        }

        //public static void SelectInterest(int index)
        //{
        //    AqualityServices.Logger.Info("[STEP] Select interest from interests list");
        //    if (!secondCard.IsInterestChecked(index))
        //    {
        //        secondCard.CheckInterestByIndex(index);
        //    }
        //}

        public static void SelectInterests(params int[] indexes)
        {
            foreach (int index in indexes)
            {
                secondCard.CheckInterestByIndex(index);
            }
        }

        public static int GetInterestsCount()
        {
            return secondCard.GetInterestsCount();
        }

        public static void ClickNextButton()
        {
            AqualityServices.Logger.Info("[STEP] Click 'Next' button to submit and to navigate to the next card");
            secondCard.ClickNextButton();
        }
    }
}
