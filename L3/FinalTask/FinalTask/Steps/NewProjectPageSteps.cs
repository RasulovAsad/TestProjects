using Aquality.Selenium.Browsers;
using FinalTask.Forms.Pages;
using NUnit.Framework;

namespace FinalTask.Steps
{
    public static class NewProjectPageSteps
    {
        private static readonly NewProjectPage newProjectPage = new NewProjectPage();

        public static void CheckThatProjectPageIsDisplayed()
        {
            AqualityServices.Logger.Info("[STEP] Checking that home page is displayed");
            Assert.IsTrue(newProjectPage.IsDisplayed, "Project page should be displayed");
        }

        public static void CheckThatTestAppearedInTable(string id, string testName)
        {
            Assert.IsTrue(newProjectPage.IsTestPresent(id), "Test should be displayed");
            Assert.AreEqual(newProjectPage.GetTestName(id), testName);
        }
    }
}
