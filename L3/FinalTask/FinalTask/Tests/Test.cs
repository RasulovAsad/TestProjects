using Aquality.Selenium.Browsers;
using FinalTask.API;
using FinalTask.Data;
using FinalTask.Extensions;
using FinalTask.Models;
using FinalTask.Steps;
using FinalTask.Tests.Base;
using FinalTask.Utilities;
using NUnit.Framework;

namespace FinalTask.Tests
{
    public class Test : BaseWebTest
    {
        private string testId;
        [Test(Description = "TC_1: Add new project and add test result with log and screenshot to it")]
        public void AddProjectAndTestResult()
        {
            var token = Api.GetToken(TestData.Variant);
            Assert.IsNotNull(token, "Token sholud not be Null");

            BasicAuthUtil.Authenticate(UserCredentials.Login, UserCredentials.Password);
            HomePageSteps.CheckThatHomePageIsDisplayed();
            HomePageSteps.CheckThatHomePageElementsAreDisplayed(TestData.ProjectName);
            HomePageSteps.AddCookiesAndRefreshPage("token", token);
            HomePageSteps.CheckThatVariantNumberIsExpected(TestData.Variant);
            var projectId = HomePageSteps.GetProjectId(TestData.ProjectName);
            HomePageSteps.GoToProject(TestData.ProjectName);

            NexagePageSteps.CheckThatNexagePageIsDisplayed();
            var tests = Api.GetAllTestsByProjectId(projectId);
            tests.OrderListByDescending((x, y) => x.StartTime.CompareTo(y.StartTime));
            NexagePageSteps.CheckThatTestsFromApiAreEqualToPage(tests);
            NexagePageSteps.GoToHomePage();

            HomePageSteps.CheckThatHomePageIsDisplayed();
            HomePageSteps.AddNewProject(TestData.NewProjectName);
            HomePageSteps.SwitchToPreviousTab();
            projectId = HomePageSteps.GetProjectId(TestData.NewProjectName);
            HomePageSteps.GoToProject(TestData.NewProjectName);
            var methodName = TestContext.CurrentContext.Test.FullName;
            var test = new TestModel(
                method: methodName,
                name: ScenarioName,
                startTime: startTime,
                sessionId: sessionId,
                projectName: TestData.NewProjectName,
                env: Environment.UserName,
                browserName: AqualityServices.Browser.BrowserName.ToString()
                );
            testId = Api.PutTest(test);
            NewProjectPageSteps.CheckThatTestAppearedInTable(testId, ScenarioName);
            Api.AddAttachmentToTest(testId, Convert.ToBase64String(AqualityServices.Browser.GetScreenshot()), "image/png");
            Api.AddLogToTest(testId, LogUtil.GetLogs());
        }

        [TearDown]
        public void SaveTestResult()
        {
            Api.UpdateTest(testId, TestContext.CurrentContext.Result.Outcome.ToString(), DateTimeUtil.GetFormattedTime(DateTime.Now));
        }
    }
}