using NUnit.Framework;
using VKApiTesting.Forms.Pages;

namespace VKApiTesting.Steps
{
    public static class ProfilePageSteps
    {
        private static readonly ProfilePage profilePage = new ProfilePage();
        private const int userIdLentgh = 9;

        public static void ProfilePageIsDisplayed()
        {
            Assert.IsTrue(profilePage.State.WaitForDisplayed(), "Profile page should be displayed");
        }

        public static void CheckThatPostIsPresent(int userId, int id)
        {
            Assert.IsTrue(profilePage.WallPostIsPresent(userId, id), "Post should be present");
            Assert.IsTrue(profilePage.PostTextIsPresent(userId, id), "Text should be present");
            Assert.IsTrue(profilePage.PostAuthorIsPresent(userId, id), "Author should be present");
        }

        public static void CheckThatPostIsDeleted(int userId, int id)
        {
            Assert.IsTrue(profilePage.PostIsDeleted(userId, id), "Post should be deleted");
        }

        public static string GetWallPostText(int userId, int id)
        {
            return profilePage.GetWallPostText(userId, id);
        }

        public static int GetAuthorId(int userId, int id)
        {
            var authorUrl = profilePage.GetWallPostAuthorUrl(userId, id);
            var authorId = authorUrl.Split("id").LastOrDefault();
            return Convert.ToInt32(authorId);
        }

        public static void LikePost(int userId, int id)
        {
            profilePage.LikeButtonClick(userId, id);
        }
    }
}
