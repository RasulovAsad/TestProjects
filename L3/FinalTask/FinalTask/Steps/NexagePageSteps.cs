using Aquality.Selenium.Browsers;
using FinalTask.Forms.Pages;
using FinalTask.Models;
using NUnit.Framework;

namespace FinalTask.Steps
{
    public static class NexagePageSteps
    {
        private static readonly NexagePage nexagePage = new NexagePage();

        public static void CheckThatNexagePageIsDisplayed()
        {
            AqualityServices.Logger.Info("[STEP] Checking that home page is displayed");
            Assert.IsTrue(nexagePage.IsDisplayed, "Nexage page should be displayed");
        }

        public static void CheckThatTestsFromApiAreEqualToPage(List<TestModel> models)
        {
            AqualityServices.Logger.Info("[STEP] Checking that tests from API are equal to tests on page");
            var actualList = models.Select(n => n.Name).Take(nexagePage.GetTestsListCount());
            var expectedList = new List<string>();
            for (int i = 1; i < nexagePage.GetTestsListCount(); i++)
            {
                expectedList.Add(nexagePage.GetTestName(i));
            }

            CollectionAssert.AreEqual(expectedList, actualList);
        }

        public static void GoToHomePage()
        {
            AqualityServices.Logger.Info("[STEP] Going to the Home page");
            nexagePage.ClickHomeLink();
        }
    }
}
