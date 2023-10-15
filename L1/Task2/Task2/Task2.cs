using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Task2
{
    public class Tests
    {
        WebDriver driver;
        string randomUsername;
        string randomPassword;

        [SetUp]
        public void Setup()
        {
            randomUsername = "randomUsername";
            randomPassword = "randomPassword";
        }

        [TearDown]
        public void Teardown()
        {
           driver.Quit();
        }

        [Test]
        public void ChromeTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);

            driver.Navigate().GoToUrl("https://store.steampowered.com/");
            
            var pageUrl = driver.Url;
            Assert.AreEqual("https://store.steampowered.com/", pageUrl, "Main page didn't open");

            var logInButton = driver.FindElement(By.XPath("//a[contains(@class, 'global_action_link') and @href='https://store.steampowered.com/login/?redir=&redir_ssl=1&snr=1_4_4__global-header']"));
            logInButton.Click();
            pageUrl = driver.Url;
            Assert.AreEqual("https://store.steampowered.com/login/?redir=&redir_ssl=1&snr=1_4_4__global-header", pageUrl, "Sign In page didn't open.");

            var usernameInput = driver.FindElement(By.XPath("//*[@id=\"responsive_page_template_content\"]/div/div[1]/div/div/div/div[2]/div/form/div[1]/input"));
            var passwordInput = driver.FindElement(By.XPath("//*[@id=\"responsive_page_template_content\"]/div/div[1]/div/div/div/div[2]/div/form/div[2]/input"));
            usernameInput.SendKeys(randomUsername);
            passwordInput.SendKeys(randomPassword);

            var signInErrorMessage = driver.FindElement(By.XPath("//div[contains(@class, 'newlogindialog_FormError')]"));

            var submitButton = driver.FindElement(By.XPath("//button[contains(@class, 'newlogindialog_SubmitButton')]"));
            submitButton.Click();
            var loadingButton = driver.FindElement(By.XPath("//button[contains(@class, 'newlogindialog_Loading')]"));
            Assert.That(loadingButton.Displayed, "Loading sign wasn't displayed");

            var errorMessage = signInErrorMessage.Text;
            Assert.IsNotEmpty(errorMessage, "Error message wasn't displayed");
        }

        [Test]
        public void FirefoxTest()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);

            driver.Navigate().GoToUrl("https://store.steampowered.com/");

            var pageUrl = driver.Url;
            Assert.AreEqual("https://store.steampowered.com/", pageUrl, "Main page didn't open");

            var logInButton = driver.FindElement(By.XPath("//a[contains(@class, 'global_action_link') and @href='https://store.steampowered.com/login/?redir=&redir_ssl=1&snr=1_4_4__global-header']"));
            logInButton.Click();
            pageUrl = driver.Url;
            Assert.AreEqual("https://store.steampowered.com/login/?redir=&redir_ssl=1&snr=1_4_4__global-header", pageUrl, "Sign In page didn't open.");

            var usernameInput = driver.FindElement(By.XPath("//*[@id=\"responsive_page_template_content\"]/div/div[1]/div/div/div/div[2]/div/form/div[1]/input"));
            var passwordInput = driver.FindElement(By.XPath("//*[@id=\"responsive_page_template_content\"]/div/div[1]/div/div/div/div[2]/div/form/div[2]/input"));
            usernameInput.SendKeys(randomUsername);
            passwordInput.SendKeys(randomPassword);

            var signInErrorMessage = driver.FindElement(By.XPath("//div[contains(@class, 'newlogindialog_FormError')]"));

            var submitButton = driver.FindElement(By.XPath("//button[contains(@class, 'newlogindialog_SubmitButton')]"));
            submitButton.Click();
            var loadingButton = driver.FindElement(By.XPath("//button[contains(@class, 'newlogindialog_Loading')]"));
            Assert.That(loadingButton.Displayed, "Loading sign wasn't displayed");

            var errorMessage = signInErrorMessage.Text;
            Assert.IsNotEmpty(errorMessage, "Error message wasn't displayed");
        }


    }
}