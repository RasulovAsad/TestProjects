using Aquality.Selenium.Browsers;
using NUnit.Framework;
using VKApiTesting.API;
using VKApiTesting.Data;
using VKApiTesting.Steps;
using VKApiTesting.Utilities;

namespace VKApiTesting.Test
{
    public class Tests : BaseWebTest
    {
        [Test]
        public void PostActionsTest()
        {
            AqualityServices.Logger.Info("[UI] Go to the home page and sign in");
            SignInSteps.SignIn(UserCredentials.Login, UserCredentials.Password);
            NewsPageSteps.NewsPageIsDisplayed();
            NewsPageSteps.CheckThatNewsPageElementsAreDisplayed();

            AqualityServices.Logger.Info("[UI] Go to the 'My profile' page");
            NewsPageSteps.GoToMyProfile();
            ProfilePageSteps.ProfilePageIsDisplayed();

            AqualityServices.Logger.Info("[API] Create new post");
            string text = RandomGenerator.GetUniqueKey(RandomGenerator.GetRandomNumber(TestData.MaxLengthForPostText));
            int postId = VKApi.CreatePost(text);
            int userId = VKApi.GetUserId();
            ProfilePageSteps.CheckThatPostIsPresent(userId, postId);
            Assert.AreEqual(userId, ProfilePageSteps.GetAuthorId(userId, postId), "Author Ids should match");
            Assert.AreEqual(text, ProfilePageSteps.GetWallPostText(userId, postId), "Texts should be the same");

            AqualityServices.Logger.Info("[API] Upload image to the album");
            int albumId = VKApi.GetAlbumId(userId);
            int photoId = VKApi.UploadImageToAlbum(albumId, TestData.ImagePath);

            AqualityServices.Logger.Info("[API] Edit post");
            string editedText = RandomGenerator.GetUniqueKey(RandomGenerator.GetRandomNumber(TestData.MaxLengthForPostText));
            VKApi.EditPost(postId, editedText, userId, photoId);
            Assert.AreEqual(editedText, ProfilePageSteps.GetWallPostText(userId, postId), "Texts should be the same");
            AqualityServices.Logger.Info("[STEP] Download image from album");
            string downloadPath = TestData.DownloadedImagePath;
            ApiHelper.DownloadImage(VKApi.GetImageUrl(userId, photoId), downloadPath);
            Assert.IsTrue(ImageComparator.CompareImages(downloadPath, TestData.ImagePath), "Images should match");

            AqualityServices.Logger.Info("[API] Create new comment");
            VKApi.CreateComment(postId, text);

            AqualityServices.Logger.Info("[UI] Like post");
            ProfilePageSteps.LikePost(userId, postId);
            Assert.IsTrue(VKApi.IsLiked(userId, postId, "post"), "Post should be liked by user");

            AqualityServices.Logger.Info("[API] Delete post");
            VKApi.DeletePost(postId);
            ProfilePageSteps.CheckThatPostIsDeleted(userId, postId);
        }
    }
}