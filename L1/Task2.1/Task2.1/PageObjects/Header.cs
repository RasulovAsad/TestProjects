using OpenQA.Selenium;
using Task2._1.Driver;

namespace Task2._1.PageObjects
{
    public class Header
    {
        private IWebElement _logo = Singleton.Driver().FindElement(By.XPath("//span[@id='logo_holder']/a/img"));

        private IWebElement _storeLink = Singleton.Driver().FindElement(By.XPath("//div[contains(@class, 'supernav_container')]/a[1 and contains(@class, 'menuitem')]"));
        private IWebElement _communityLink = Singleton.Driver().FindElement(By.XPath("//div[contains(@class, 'supernav_container')]/a[2 and contains(@class, 'menuitem')]"));
        private IWebElement _aboutLink = Singleton.Driver().FindElement(By.XPath("//div[contains(@class, 'supernav_container')]/a[3 and contains(@class, 'menuitem')]"));
        private IWebElement _supportLink = Singleton.Driver().FindElement(By.XPath("//div[contains(@class, 'supernav_container')]/a[4 and contains(@class, 'menuitem')]"));

        private IWebElement _installSteamButton = Singleton.Driver().FindElement(By.XPath("//a[contains(@class, 'header_installsteam_btn_content')]"));
        private IWebElement _loginLink = Singleton.Driver().FindElement(By.XPath("//div[@id='global_action_menu']/a"));
        private IWebElement _languagesMenu = Singleton.Driver().FindElement(By.XPath("//span[@id='language_pulldown']"));

        public void ClickLogo()
        {
            _logo.Click();
        }
        public void ClickStoreLink()
        {
            _storeLink.Click();
        }
        public void ClickCommunityLink()
        {
            _communityLink.Click();
        }
        public void ClickAboutLink()
        {
            _aboutLink.Click();
        }
        public void ClickSupportLink()
        {
            _supportLink.Click();
        }

        public void ClickInstallSteamButton()
        {
            _installSteamButton.Click();
        }
        public void ClickLogin()
        {
            _loginLink.Click();
        }
        public void ClickLanguagesMenu()
        {
            _languagesMenu.Click();
        }
    }
}
