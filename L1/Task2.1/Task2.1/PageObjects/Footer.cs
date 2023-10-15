using OpenQA.Selenium;
using Task2._1.Driver;

namespace Task2._1.PageObjects
{
    public class Footer
    {
        private IWebElement _steamLogo;
        private IWebElement _valveLogo;

        //Footer Links
        private IWebElement _privacyPolicyLink = Singleton.Driver().FindElement(By.XPath("//div[@id='footer_text']/div[2]/a[1]"));
        private IWebElement _legalLink = Singleton.Driver().FindElement(By.XPath("//div[@id='footer_text']/div[2]/a[2]"));
        private IWebElement _steamSubscriberAgreementLink = Singleton.Driver().FindElement(By.XPath("//div[@id='footer_text']/div[2]/a[3]"));
        private IWebElement _refundsLink = Singleton.Driver().FindElement(By.XPath("//div[@id='footer_text']/div[2]/a[4]"));
        private IWebElement _cookiesLink = Singleton.Driver().FindElement(By.XPath("//div[@id='footer_text']/div[2]/a[5]"));

        //Valve Links
        private IWebElement _aboutValveLink = Singleton.Driver().FindElement(By.XPath("//div[contains(@class, 'valve_links')]/a[1]"));
        private IWebElement _jobsLink = Singleton.Driver().FindElement(By.XPath("//div[contains(@class, 'valve_links')]/a[2]"));
        private IWebElement _steamworksLink = Singleton.Driver().FindElement(By.XPath("//div[contains(@class, 'valve_links')]/a[3]"));
        private IWebElement _steamDistributionLink = Singleton.Driver().FindElement(By.XPath("//div[contains(@class, 'valve_links')]/a[4]"));
        private IWebElement _supportLink = Singleton.Driver().FindElement(By.XPath("//div[contains(@class, 'valve_links')]/a[5]"));
        private IWebElement _giftCardsLink = Singleton.Driver().FindElement(By.XPath("//div[contains(@class, 'valve_links')]/a[6]"));
        private IWebElement _steamFacebookLink = Singleton.Driver().FindElement(By.XPath("//div[contains(@class, 'valve_links')]/a[7]"));
        private IWebElement _steamTwitterLink = Singleton.Driver().FindElement(By.XPath("//div[contains(@class, 'valve_links')]/a[8]"));


        public void ClickSteamLogo()
        {
            _steamLogo.Click();
        }
        public void ClickValveLogo()
        {
            _valveLogo.Click();
        }
        public void ClickPrivacyPolicyLink()
        {
            _privacyPolicyLink.Click();
        }
        public void ClickLegalLink()
        {
            _legalLink.Click();
        }
        public void ClickSubscriberAgreementsLink()
        {
            _steamSubscriberAgreementLink.Click();
        }
        public void ClickRefundsLink()
        {
            _refundsLink.Click();
        }
        public void ClickCookiesLink()
        {
            _cookiesLink.Click();
        }
        public void ClickAboutValveLink()
        {
            _aboutValveLink.Click();
        }
        public void ClickJobsLink()
        {
            _jobsLink.Click();
        }
        public void ClickSteamWorksLink()
        {
            _steamworksLink.Click();
        }
        public void ClickSteamDistributionLink()
        {
            _steamDistributionLink.Click();
        }
        public void ClickSupportLink()
        {
            _supportLink.Click();
        }
        public void ClickGiftCardsLink()
        {
            _giftCardsLink.Click();
        }
        public void ClickSteamFacebookLink()
        {
            _steamFacebookLink.Click();
        }
        public void ClickSteamTwitterLink()
        {
            _steamTwitterLink.Click();
        }
    }
}
