using Task2._1.Configuration;
using Task2._1.Driver;
using Task2._1.Models;
using Task2._1.PageObjects;

namespace Task2._1
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
            Singleton.Driver().Navigate().GoToUrl(Utilities.GetConfiguration().AppUrl);
            Singleton.Driver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Utilities.GetConfiguration().Wait);
        }

        [TearDown]
        public void TearDown()
        {
            Singleton.CloseDriver();
        }

        [Test]
        public void PrivacyPolicyTest()
        {
            var mainPage = new MainPage();
            Assert.IsTrue(mainPage.IsMainPageOpened(), "Main page is not opened");
            
            var footer = new Footer();
            footer.ClickPrivacyPolicyLink();
            Singleton.Driver().SwitchTo().Window(Singleton.Driver().WindowHandles[1]);
            var privacyPolicyPage = new PrivacyPolicyPage();
            Assert.IsTrue(privacyPolicyPage.IsPrivacyPolicyPageOpened(), "Privacy Policy page is not opened");

            var languages = Utilities.GetTestData()["languages"];
            foreach (var language in languages)
            {
                Assert.IsTrue(privacyPolicyPage.IsLanguageLinkExist(language.ToString()), "There is no such element on page");
            }
            Assert.AreEqual(DateTime.Today.Year, privacyPolicyPage.GetRevisionYear(), "Policy revision didn't signed this year.");
        }

        [Test]
        public void GameSearchTest()
        {
            var mainPage = new MainPage();
            Assert.IsTrue(mainPage.IsMainPageOpened(), "Main page is not opened");

            string searchPhrase = (Utilities.GetTestData()["searchPhrase"]).ToString();
            mainPage.SearchSendKey(searchPhrase);
            mainPage.ClickSearchButton();
            
            var searchPage = new SearchPage();
            Assert.IsTrue(searchPage.IsSearchPageOpened(), "Search page is not opened");
            Assert.AreEqual(searchPhrase, searchPage.GetSearchBarText(), "Search box doesn't contain searched name");
            var fistSearchResult = searchPage.GetSearchItemByOrder(1);
            var secondSearchResult = searchPage.GetSearchItemByOrder(2);
            Assert.AreEqual(searchPhrase, searchPage.GetSearchItemName(fistSearchResult), "The first name isn't equal to searched name");

            SearchResultModel firstResult = new SearchResultModel(
                searchPage.GetSearchItemName(fistSearchResult),
                searchPage.GetSearchItemReleaseDate(fistSearchResult),
                searchPage.GetSearchItemReviewSummary(fistSearchResult),
                searchPage.GetSearchItemPrice(fistSearchResult));

            SearchResultModel secondResult = new SearchResultModel(
                searchPage.GetSearchItemName(secondSearchResult),
                searchPage.GetSearchItemReleaseDate(secondSearchResult),
                searchPage.GetSearchItemReviewSummary(secondSearchResult),
                searchPage.GetSearchItemPrice(secondSearchResult));

            searchPage.SearchSendKey(secondResult.Name);
            fistSearchResult = searchPage.GetSearchItemByOrder(1);
            Assert.AreEqual(secondResult.Name, searchPage.GetSearchItemName(fistSearchResult), "The first name isn't equal to searched name");
        }
    }
}