using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Task2._1.Configuration;
using Task2._1.Driver;

namespace Task2._1.PageObjects
{
    public class PrivacyPolicyPage
    {
        private static WebDriverWait wait = new WebDriverWait(Singleton.Driver(), TimeSpan.FromSeconds(Utilities.GetConfiguration().Wait));
        private IWebElement _languageLink;
        private IWebElement _revisonDateElement = Singleton.Driver().FindElement(By.XPath("/html/body/div/div[7]/div[6]/div[1]/div/div[2]/div[2]/div/div[2]/i[3]"));
        private IWebElement _newsColumn = Singleton.Driver().FindElement(By.XPath("//div[@id='newsColumn']"));

        public bool IsPrivacyPolicyPageOpened()
        {
            return _newsColumn.Displayed;
        }

        public bool IsLanguageLinkExist(string language)
        {

            _languageLink = wait.Until(e => e.FindElement(By.XPath($"//div[@id='languages']/a[@href='https://store.steampowered.com/privacy_agreement/{language}/']")));
            if (_languageLink.Displayed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetRevisionYear()
        {
            string elementText = _revisonDateElement.Text;
            string toBeSearched = "Revision Date: ";
            string date = elementText.Substring(elementText.IndexOf(toBeSearched) + toBeSearched.Length);

            DateOnly revisionDate = DateOnly.Parse(date);
            return revisionDate.Year;
        }

    }
}
