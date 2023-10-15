using NUnit.Framework;
using Userinterface.Steps;
using Userinterface.TestingData;
using Userinterface.Utilities;

namespace Userinterface.Tests
{
    public class Test : BaseWebTest
    {
        private const int numberOfInterests = 3;
        private const int minCheckboxPosition = 1;
        private const int maxCheckboxPosition = 20;
        private readonly int[] excludedCheckboxPositions = { 17, 20 };

        private void InitialStep()
        {
            HomePageSteps.HomePageIsPresent();
            HomePageSteps.StartLinkIsPresent();
            HomePageSteps.ClickStartLink();
            GamePageSteps.GamePageIsPresent();
            GamePageSteps.CheckThatGamePageElementsAreDisplayed();
        }

        [Test(Description = "Fill first two cards")]
        public void FillFirstTwoCards()
        {
            InitialStep();
            FirstCardSteps.FirstCardIsPresent();
            FirstCardSteps.CheckThatFirstCardElementsAreDisplayed();
            string email = RandomGenerator.GetUniqueKey(TestData.EmailLength);
            string password = RandomGenerator.GetUniqueKey(TestData.PasswordLength, email);
            string domain = RandomGenerator.GetUniqueKey(TestData.DomainLength);
            FirstCardSteps.FillAllTextFieldsInFirstCard(email, password, domain);
            FirstCardSteps.SelectDropdownItem(RandomGenerator.GetRandomNumber(FirstCardSteps.GetDropdownItemsCount() - 1));
            FirstCardSteps.CheckTermCheckBoxIsCheckedOrNot(true);
            FirstCardSteps.CheckTermCheckBox();
            FirstCardSteps.CheckTermCheckBoxIsCheckedOrNot();
            FirstCardSteps.ClickNextLink();

            SecondCardSteps.SecondCardIsPresent();
            SecondCardSteps.CheckThatSecondCardElementsAreDisplayed();
            SecondCardSteps.ClickUploadImage();
            SecondCardSteps.UploadImage(TestData.ImageName);
            SecondCardSteps.CheckUnselectAllCheckBoxIsCheckedOrNot(true);
            SecondCardSteps.CheckUnselectAllCheckBox();
            SecondCardSteps.CheckUnselectAllCheckBoxIsCheckedOrNot();
            var arrayOfInterestsIndexes = RandomGenerator.GenerateRandomArrayWithUniqueBValues(numberOfInterests, minCheckboxPosition, maxCheckboxPosition, excludedCheckboxPositions);
            SecondCardSteps.SelectInterests(arrayOfInterestsIndexes);
            SecondCardSteps.ClickNextButton();

            ThirdCardSteps.ThirdCardIsPresent();
        }

        [Test(Description = "Accept cookies")]
        public void AcceptCookies()
        {
            InitialStep();
            GamePageSteps.CheckThatCookiesFormDisplayed();
            GamePageSteps.AcceptCookies();
            GamePageSteps.CheckThatCookiesFormClosed();
        }

        [Test(Description = "Check timer expected time")]
        public void CheckTimerExpectedTime()
        {
            InitialStep();
            GamePageSteps.CheckThatTimerIsExpected(TestData.ExpectedTime);
        }

        [Test(Description = "Close help form")]
        public void CloseHelpForm()
        {
            InitialStep();
            GamePageSteps.ClickSendToBottomButton();
            GamePageSteps.CheckThatHelpFormClosed();
        }
    }
}
