using OpenQA.Selenium;
using Task2._1.Driver;

namespace Task2._1.PageObjects
{
    public class MainPage
    {
        private IWebElement _content = Singleton.Driver().FindElement(By.XPath("//div[contains(@class, 'home_page_body_ctn ')]"));
        private IWebElement _searchBar = Singleton.Driver().FindElement(By.XPath("//input[@id='store_nav_search_term']"));
        private IWebElement _searchButton = Singleton.Driver().FindElement(By.XPath("//a[@id='store_search_link']/img"));

        public bool IsMainPageOpened()
        {
            return _content.Displayed;
        }



        public void SearchSendKey(string key)
        {
            _searchBar.Clear();
            _searchBar.SendKeys(key);
        }

        public void ClickSearchButton()
        {
            _searchButton.Click();
        }
    }
}
