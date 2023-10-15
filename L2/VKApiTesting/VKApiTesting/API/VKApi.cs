using Aquality.Selenium.Browsers;
using Newtonsoft.Json;
using RestSharp;
using VKApiTesting.Configurations;
using VKApiTesting.Constants;
using VKApiTesting.Data;
using VKApiTesting.Models.Albums;
using VKApiTesting.Models.Likes;
using VKApiTesting.Models.Photo;
using VKApiTesting.Models.Post;
using VKApiTesting.Models.SendToServer;
using VKApiTesting.Models.UploadServer;
using VKApiTesting.Models.Users;
using VKApiTesting.Utilities;

namespace VKApiTesting.API
{
    public static class VKApi
    {
        private static readonly RestClient client = new RestClient(ApiConfiguration.ApiUrl);
        private static readonly string imageFolderPath = Path.Combine(Environment.CurrentDirectory, "Resources/Images");


        private static RestRequest VkRequest(string method) =>
            new RestRequest(string.Format(Endpoints.VkRequest, method, UserCredentials.AccessToken, ApiConfiguration.ApiVersion));

        public static int CreatePost(string text)
        {
            AqualityServices.Logger.Info("Create post using API");
            var response = ApiHelper.ExecuteRequest(client, VkRequest(string.Format(Endpoints.CreatePost, text)), Method.Post);
            var model = JsonConvert.DeserializeObject<WallPostResponse>(response.Content).Response;
            return model.PostId;
        }

        public static void EditPost(int postId, string message, int userId, int photoId)
        {
            AqualityServices.Logger.Info("Edit post using API");
            ApiHelper.ExecuteRequest(client, VkRequest(string.Format(Endpoints.EditPost, postId, message, userId, photoId)), Method.Post);
        }
        public static void DeletePost(int postId)
        {
            AqualityServices.Logger.Info("Delete post using API");
            ApiHelper.ExecuteRequest(client, VkRequest(string.Format(Endpoints.DeletePost, postId)), Method.Post);
        }
        public static void CreateComment(int postId, string message)
        {
            AqualityServices.Logger.Info("Create comment using API");
            ApiHelper.ExecuteRequest(client, VkRequest(string.Format(Endpoints.CreateComment, postId, message)), Method.Post);
        }

        public static bool IsLiked(int userId, int itemId, string type)
        {
            AqualityServices.Logger.Info("Check that the iten is liked using API");
            var response = ApiHelper.ExecuteRequest(client, VkRequest(string.Format(Endpoints.IsLiked, userId, itemId, type)), Method.Get);
            var model = JsonConvert.DeserializeObject<IsLikedResponse>(response.Content).Response;
            return model.Liked == 1;
        }

        private static string GetImageUploadUrl(int albumId)
        {
            AqualityServices.Logger.Info("Get image upload url");
            var response = ApiHelper.ExecuteRequest(client, VkRequest(string.Format(Endpoints.GetUploadServer, albumId)), Method.Get);
            var model = JsonConvert.DeserializeObject<GetUploadServerResponse>(response.Content).Response;
            return model.UploadUrl;
        }

        private static string GetUploadImageToServerUrl(int albumId, string imageName)
        {
            AqualityServices.Logger.Info("Send image to the server");
            RestRequest restRequest = new RestRequest(GetImageUploadUrl(albumId));
            restRequest.AddFile("photo", Path.Combine(imageFolderPath, imageName), "multipart/form-data");
            var response = ApiHelper.ExecuteRequest(client, restRequest, Method.Post);
            var model = JsonConvert.DeserializeObject<SendPhotoToServerResponse>(response.Content);
            return string.Format(Endpoints.SendPhotoToServer, model.Server, model.Aid, model.PhotosList, model.Hash);
        }

        public static int UploadImageToAlbum(int albumId, string imageName)
        {
            AqualityServices.Logger.Info("Save image to the album");
            var response = ApiHelper.ExecuteRequest(client, VkRequest(string.Format(Endpoints.SavePhoto, GetUploadImageToServerUrl(albumId, imageName))), Method.Post);
            var model = JsonConvert.DeserializeObject<PhotoResponse>(response.Content).Response.FirstOrDefault();
            return model.Id;
        }

        public static int GetUserId()
        {
            var response = ApiHelper.ExecuteRequest(client, VkRequest(Endpoints.GetUsers), Method.Get);
            var model = JsonConvert.DeserializeObject<UsersGetResponse>(response.Content).Response.FirstOrDefault();
            return model.userId;
        }

        public static string GetImageUrl(int userId, int photoId)
        {
            var response = ApiHelper.ExecuteRequest(client, VkRequest(string.Format(Endpoints.GetPhoto, userId, photoId)), Method.Get);
            var model = JsonConvert.DeserializeObject<PhotoResponse>(response.Content).Response.FirstOrDefault();
            return model.Sizes.LastOrDefault().Url;
        }

        public static int GetAlbumId(int userId)
        {
            var response = ApiHelper.ExecuteRequest(client, VkRequest(string.Format(Endpoints.GetAlbums, userId)), Method.Get);
            var model = JsonConvert.DeserializeObject<GetAlbumsResponse>(response.Content).Response;
            return model.Items.FirstOrDefault().Id;
        }
    }
}