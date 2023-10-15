using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Task2._1.Configuration;
using Task2._1.Driver;

namespace Task2._1.PageObjects
{
    public class SearchPage
    {
        private static WebDriverWait wait = new WebDriverWait(Singleton.Driver(), TimeSpan.FromSeconds(Utilities.GetConfiguration().Wait));
        private IWebElement _searchOptionsColumn = wait.Until(e => e.FindElement(By.XPath("//div[@id='additional_search_options']")));
        private IWebElement _searchBar = wait.Until(e => e.FindElement(By.XPath("//input[@id='term']")));
        private IWebElement _searchItem;

        public bool IsSearchPageOpened()
        {
            return _searchOptionsColumn.Displayed;
        }
        public void SearchSendKey(string key)
        {
            _searchBar.SendKeys(key);
        }

        public string GetSearchBarText()
        {
            return _searchBar.GetAttribute("value");
        }

        public IWebElement GetSearchItemByOrder(int order)
        {
            return _searchItem = Singleton.Driver().FindElement(By.XPath($"//div[contains(@id, 'search_resultsRows')]/a[{order}]/div[contains(@class, 'responsive_search_name_combined')]"));
        }
        public string GetSearchItemName(IWebElement item)
        {
            return item.FindElement(By.XPath($"//span[contains(@class, 'title')]")).Text;
        }
        public DateTime GetSearchItemReleaseDate(IWebElement item)
        {
            return DateTime.Parse(item.FindElement(By.XPath("//div[contains(@class, 'search_released ')]")).Text);
        }
        public string GetSearchItemReviewSummary(IWebElement item)
        {
            var reviewElement = item.FindElement(By.XPath("//span[contains(@class, 'search_review_summary')]"));

            return reviewElement.GetAttribute("data-tooltip-html");
        }
        public double GetSearchItemPrice(IWebElement item)
        {
            var priceElement = item.FindElement(By.XPath("//div[contains(@class, 'search_price_discount_combined')]"));
            string price = priceElement.GetAttribute("data-price-final");
            return Convert.ToDouble(price);
        }
    }
}
