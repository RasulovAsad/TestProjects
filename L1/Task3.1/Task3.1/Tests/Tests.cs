using OpenQA.Selenium;
using Serilog;
using Task3._1.Framework.Driver;
using Task3._1.Framework.Models.Base;
using Task3._1.Framework.Utilities;
using Task3._1.Models;
using Task3._1.PageObjects;

namespace Task3._1.Tests
{
    public class Tests : BaseTest
    {
        [Test]
        public void Alerts()
        {
            Log.Information("Starting Alerts test");

            HomePage homePage = new HomePage(By.XPath("//div[contains(@class, 'home-banner')]"), "Home page");
            Assert.IsTrue(homePage.IsOpen(), $"{homePage.GetName()} is not opened");
            homePage.GoToAlertsPage();

            MenuPage menuPage = new MenuPage(By.XPath("//div[contains(@class, 'main-header')]"), "Alerts, Frame & Windows");
            Assert.IsTrue(menuPage.IsOpen(), $"{menuPage.GetName()} is not opened");
            menuPage.SelectAlertsMenu();

            Assert.IsTrue(menuPage.Alerts().IsOpen(), $"{menuPage.Alerts().GetName()} is not opened");

            menuPage.Alerts().SimpleAlert();
            Assert.AreEqual(FileReader.GetTestData()["simpleAlertMessage"], AlertUtils.GetAlertMessage(), "Wrong alert message");
            AlertUtils.DismissAlert();
            Assert.That(!AlertUtils.IsAlertPresent(), "Alert has not closed");

            menuPage.Alerts().ConfirmBoxAlert();
            Assert.AreEqual(FileReader.GetTestData()["confirmBoxMessage"], AlertUtils.GetAlertMessage(), "Wrong alert message");
            AlertUtils.AcceptAlert();
            Assert.That(!AlertUtils.IsAlertPresent(), "Alert has not closed");
            Assert.IsTrue(menuPage.Alerts().ConformationResultIsDisplayed());

            menuPage.Alerts().PromptBoxAlert();
            Assert.AreEqual(FileReader.GetTestData()["promptBoxMessage"], AlertUtils.GetAlertMessage(), "Wrong alert message");
            string randomKey = AlertUtils.GetUniqueKey(8);
            AlertUtils.SendKeysToAlert(randomKey);
            AlertUtils.AcceptAlert();
            Assert.That(!AlertUtils.IsAlertPresent(), "Alert has not closed");
            Assert.AreEqual($"You entered {randomKey}", menuPage.Alerts().GetPromptBoxResult(), "Appeared text is not equal to entered text");
        }

        [Test]
        public void IFrame()
        {
            Log.Information("Starting IFrame test");

            HomePage homePage = new HomePage(By.XPath("//div[contains(@class, 'home-banner')]"), "Home page");
            Assert.IsTrue(homePage.IsOpen(), $"{homePage.GetName()} is not opened");
            homePage.GoToAlertsPage();

            MenuPage menuPage = new MenuPage(By.XPath("//div[contains(@class, 'main-header')]"), "Alerts, Frame & Windows");
            Assert.IsTrue(menuPage.IsOpen(), $"{menuPage.GetName()} is not opened");

            menuPage.SelectNestedFramesMenu();
            
            Assert.IsTrue(menuPage.NestedFrames().IsOpen(), $"{menuPage.NestedFrames().GetName()} is not opened");

            Assert.IsTrue(menuPage.NestedFrames().ParentFrameIsDisplayed(), "Parent frame is not displayed");
            Browser.SwitchToFrame("frame1");
            Assert.IsTrue(menuPage.NestedFrames().ChildFrameIsDisplayed(), "Child frame is not displayed");
            Browser.SwitchToParentFrame();

            menuPage.SelectFramesMenu();

            Assert.IsTrue(menuPage.Frames().IsOpen(), $"{menuPage.Frames().GetName()} is not opened");

            Browser.SwitchToFrame("frame1");
            string frame1Heading = menuPage.Frames().GetSampleHeadingText();
            Browser.SwitchToParentFrame();
            Browser.SwitchToFrame("frame2");
            string frame2Heading = menuPage.Frames().GetSampleHeadingText();

            Assert.AreEqual(frame1Heading, frame2Heading);
        }

        [Test]
        [TestCaseSource("GetTestDataSource")]
        public void Tables(User user)
        {
            Log.Information("Starting Tables test");

            HomePage homePage = new HomePage(By.XPath("//div[contains(@class, 'home-banner')]"), "Home page");
            Assert.IsTrue(homePage.IsOpen(), $"{homePage.GetName()} is not opened");
            homePage.GoToElementsPage();

            MenuPage menuPage = new MenuPage(By.XPath("//div[contains(@class, 'main-header')]"), "Alerts, Frame & Windows");
            Assert.IsTrue(menuPage.IsOpen(), $"{menuPage.GetName()} is not opened");

            menuPage.SelectWebTablesMenu();
            
            Assert.IsTrue(menuPage.WebTables().IsOpen(), $"{menuPage.WebTables().GetName()} is not opened");
            menuPage.WebTables().ClickAdd();

            Thread.Sleep(300);
            Assert.IsTrue(menuPage.WebTables().RegistrationForm().IsOpen(), $"{menuPage.WebTables().RegistrationForm().GetName()} is not opened");

            menuPage.WebTables().RegistrationForm().AddUser(user);

            Log.Debug("User was added to the table");
            Assert.IsTrue(menuPage.WebTables().UserExistsInTable(user.FirstName), "Data has not appeared in a table");
            int oldCount = menuPage.WebTables().GetUsersCount();
            menuPage.WebTables().DeleteUser(oldCount);
            int newCount = menuPage.WebTables().GetUsersCount();
            Assert.That(oldCount > newCount, "Number of records has not changed");
            Log.Debug("User was deleted from the table");
            Assert.IsTrue(!menuPage.WebTables().UserExistsInTable(user.FirstName), "User has not been deleted");
        }

        [Test]
        public void Handles()
        {
            Log.Information("Starting Handles test");

            HomePage homePage = new HomePage(By.XPath("//div[contains(@class, 'home-banner')]"), "Home page");
            Assert.IsTrue(homePage.IsOpen(), $"{homePage.GetName()} is not opened");
            homePage.GoToAlertsPage();

            MenuPage menuPage = new MenuPage(By.XPath("//div[contains(@class, 'main-header')]"), "Alerts, Frame & Windows");
            Assert.IsTrue(menuPage.IsOpen(), $"{menuPage.GetName()} is not opened");
            menuPage.SelectBrowserWindowsMenu();

            Assert.IsTrue(menuPage.BrowserWindows().IsOpen(), $"{menuPage.BrowserWindows().GetName()} is not opened");

            menuPage.BrowserWindows().NewTab();
            Browser.SwitchToTab(1);

            SamplePage samplePage = new SamplePage(By.XPath("//h1[@id='sampleHeading']"), "Sample page");
            Assert.IsTrue(samplePage.IsOpen(), $"{samplePage.GetName()} is not opened");
            Browser.CloseTab();
            Browser.SwitchToTab(0);
            Assert.IsTrue(menuPage.BrowserWindows().IsOpen(), $"{menuPage.BrowserWindows().GetName()} is not opened");

            menuPage.SelectElementsMenu();
            menuPage.SelectLinksMenu();
            
            Assert.IsTrue(menuPage.Links().IsOpen(), $"{menuPage.Links().GetName()} is not opened");

            menuPage.Links().GoToHomePage();
            Browser.SwitchToTab(1);
            Assert.IsTrue(homePage.IsOpen(), $"{homePage.GetName()} is not opened");
            Browser.CloseTab();
            Browser.SwitchToTab(0);
            Assert.IsTrue(menuPage.Links().IsOpen(), $"{menuPage.Links().GetName()} is not opened");
        }

        public static IEnumerable<User> GetTestDataSource()
        {
            return FileReader.GetUsersFromTestData();
        }
    }
}