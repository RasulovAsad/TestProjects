using Aquality.Selenium.Browsers;
using FinalTask.Forms;
using FinalTask.Forms.Pages;
using NUnit.Framework;

namespace FinalTask.Steps
{
    public static class HomePageSteps
    {
        private static readonly HomePage homePage = new HomePage();
        private static readonly AddProjectForm addProjectForm = new AddProjectForm();

        public static void CheckThatHomePageIsDisplayed()
        {
            AqualityServices.Logger.Info("[STEP] Checking that home page is displayed");
            Assert.IsTrue(homePage.IsDisplayed, "Home page should be displayed");
        }

        public static void CheckThatHomePageElementsAreDisplayed(string projectName)
        {
            AqualityServices.Logger.Info("[STEP] Checking that home page elements are displayed");
            Assert.Multiple(() =>
            {
                Assert.IsTrue(homePage.IsVariantLabelDisplayed, "Variants label should be displayed");
                Assert.IsTrue(homePage.IsProjectLinkPresent(projectName), "Nexage link should be displayed");
            });

        }

        public static void AddCookiesAndRefreshPage(string key, string value)
        {
            AqualityServices.Logger.Info($"[STEP] Adding cookies key '{key}'");
            AqualityServices.Browser.Driver.Manage().Cookies.AddCookie(new OpenQA.Selenium.Cookie(key, value));
            AqualityServices.Browser.Refresh();
        }

        public static void CheckThatVariantNumberIsExpected(string expectedVariant)
        {
            AqualityServices.Logger.Info("[STEP] Checking variant number");
            Assert.IsTrue(homePage.GetVariantLabelText().Contains(expectedVariant), $"Variant should be {expectedVariant}");
        }

        public static void GoToProject(string projectName)
        {
            AqualityServices.Logger.Info($"[STEP] Navigating to the {projectName} project page");
            homePage.ClickProjectLink(projectName);
        }

        public static string GetProjectId(string projectName)
        {
            return homePage.GetProjectLinkHref(projectName).LastOrDefault().ToString();
        }

        public static void AddNewProject(string projectName)
        {
            AqualityServices.Logger.Info("[STEP] Adding new project");
            homePage.ClickAddButton();
            AqualityServices.Browser.Tabs().SwitchToLastTab();
            addProjectForm.TypeProjectName(projectName);
            addProjectForm.ClickSubmit();
        }

        public static void SwitchToPreviousTab()
        {
            AqualityServices.Browser.Tabs().CloseTab();
            AqualityServices.Browser.Tabs().SwitchToLastTab();
            AqualityServices.Browser.Refresh();
        }
    }
}
