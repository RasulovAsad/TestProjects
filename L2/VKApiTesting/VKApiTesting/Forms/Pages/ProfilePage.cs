using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace VKApiTesting.Forms.Pages
{
    public class ProfilePage : Form
    {
        private static IElement WallPost(int userId, int id) => ElementFactory.GetLabel(By.XPath($"//div[@id='post{userId}_{id}']"), "Wall post");
        private ILabel WallPostText(int userId, int id) => WallPost(userId, id).FindChildElement<ILabel>(By.XPath("//div[contains(@class,'wall_post_text')]"));
        private ILabel WallPostAuthor(int userId, int id) => WallPost(userId, id).FindChildElement<ILabel>(By.XPath("//a[@class='author']"));
        private IButton LikeButton(int userId, int id) => WallPost(userId, id).FindChildElement<IButton>(By.XPath("//span[contains(@class,'_like_button_icon')]"));

        public ProfilePage() : base(By.XPath("//div[contains(@class,'ProfileWrapper')]"), "My Profile page") { }

        public bool WallPostIsPresent(int userId, int id) => WallPost(userId, id).State.WaitForDisplayed();
        public bool PostTextIsPresent(int userId, int id) => WallPostText(userId, id).State.WaitForExist();
        public bool PostAuthorIsPresent(int userId, int id) => WallPostAuthor(userId, id).State.WaitForExist();
        public string GetWallPostText(int userId, int id) => WallPostText(userId, id).Text;
        public string GetWallPostAuthorUrl(int userId, int id) => WallPostAuthor(userId, id).GetAttribute("href");
        public void LikeButtonClick(int userId, int id) => LikeButton(userId, id).Click();
        public bool PostIsDeleted(int userId, int id) => !WallPost(userId, id).JsActions.IsElementOnScreen();
    }
}
