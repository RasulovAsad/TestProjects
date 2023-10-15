using Newtonsoft.Json;
using RestAPITesting.Models;
using RestAPITesting.Utilities;
using RestSharp;

namespace RestAPITesting.API
{
    public static class Api
    {
        private static string GetJsonValue(string valuePath) => JsonHandler.GetValue("Resources/config.json", valuePath);

        private static readonly RestClient client = new RestClient(GetJsonValue("apiUrl"));

        public static RestResponse GetPosts()
        {
            var request = new RestRequest(GetJsonValue("getPosts"));
            return RequestHelper.ExecuteRequest(client, request, Method.Get); ;
        }

        public static RestResponse GetPostById(int id)
        {
            var request = new RestRequest(string.Format(GetJsonValue("getPost"), id.ToString()));
            return RequestHelper.ExecuteRequest(client, request, Method.Get);
        }

        public static RestResponse CreatePost(Post post)
        {
            var request = new RestRequest(GetJsonValue("getPosts"));
            request.AddObject(post);
            return RequestHelper.ExecuteRequest(client, request, Method.Post);
        }

        public static RestResponse GetUsers()
        {
            var request = new RestRequest(GetJsonValue("getUsers"));
            return RequestHelper.ExecuteRequest(client, request, Method.Get);
        }

        public static RestResponse GetUserById(int id)
        {
            var request = new RestRequest(string.Format(GetJsonValue("getUser"), id.ToString()));
            return RequestHelper.ExecuteRequest(client, request, Method.Get);
        }
        public static int GetNewPostId()
        {
            var posts = JsonConvert.DeserializeObject<List<Post>>(GetPosts().Content);
            return posts.Count + 1;
        }
    }
}
