using Newtonsoft.Json;
using NUnit.Framework;
using RestAPITesting.API;
using RestAPITesting.Models;
using RestAPITesting.Steps;
using RestAPITesting.Utilities;
using System.Net;

namespace RestAPITesting.Tests
{
    public class ApiTests : BaseTest
    {
        [Test(Description = "Getting all posts from API")]
        public void GetPosts()
        {
            var response = Api.GetPosts();
            ApiSteps.CheckThatStatusCodeIsExpected(HttpStatusCode.OK, response);
            Assert.AreEqual("application/json", response.ContentType, "Response shoulde be JSON");
            List<Post> posts = JsonConvert.DeserializeObject<List<Post>>(response.Content);
            Assert.That(posts, Is.Ordered.By("Id"), "List should be ordered by Id");
        }

        [Test(Description = "Getting a post by id from API")]
        public void GetPostById()
        {
            int postId = GetIdFromJson("GetPostById.postId");
            var response = Api.GetPostById(postId);
            ApiSteps.CheckThatStatusCodeIsExpected(HttpStatusCode.OK, response);
            Post post = JsonConvert.DeserializeObject<Post>(response.Content);
            int expectedUserId = GetIdFromJson("GetPostById.expectedUserId");
            ApiSteps.CheckThatValuesAreEqual(expectedUserId, post.UserId);
            ApiSteps.CheckThatValuesAreEqual(postId, post.Id);
            ApiSteps.CheckThatIsNotEmpty(post.Title);
            ApiSteps.CheckThatIsNotEmpty(post.Body);
        }

        [Test(Description = "Getting a post by non-existent id from API")]
        public void GetPostByImpossibleId()
        {
            int impossibleId = GetIdFromJson("GetPostByImpossibleId.impossiblePostId");
            var response = Api.GetPostById(impossibleId);
            ApiSteps.CheckThatStatusCodeIsExpected(HttpStatusCode.NotFound, response);
        }

        [Test(Description = "Creating and sending a post")]
        public void CreatePost()
        {
            int userId = GetIdFromJson("CreatePost.userId");
            int Id = GetIdFromJson("CreatePost.id");
            string title = RandomGenerator.GetUniqueKey(GetIdFromJson("CreatePost.titleLength"));
            string body = RandomGenerator.GetUniqueKey(GetIdFromJson("CreatePost.bodyLength"));
            Post post = new Post(userId, title, body);
            post.Id = Api.GetNewPostId();
            var response = Api.CreatePost(post);
            ApiSteps.CheckThatStatusCodeIsExpected(HttpStatusCode.Created, response);
            var responsePost = JsonConvert.DeserializeObject<Post>(response.Content);
            Assert.IsTrue(JsonHandler.CompareTwoObjects(post, responsePost));
        }

        [Test(Description = "Getting all users from API")]
        public void GetUsers()
        {
            var response = Api.GetUsers();
            ApiSteps.CheckThatStatusCodeIsExpected(HttpStatusCode.OK, response);
            List<User> users = JsonConvert.DeserializeObject<List<User>>(response.Content);
            User userToCompare = JsonHandler.GetTestDataFromJson<User>("UserToCompare.json");
            int userId = GetIdFromJson("GetUserById.userId");
            Assert.IsTrue(JsonHandler.CompareTwoObjects(userToCompare, users.GetById(userId)));
        }

        [Test(Description = "Getting a user by id from API")]
        public void GetUserById()
        {
            int userId = GetIdFromJson("GetUserById.userId");
            var response = Api.GetUserById(userId);
            ApiSteps.CheckThatStatusCodeIsExpected(HttpStatusCode.OK, response);
            User user = JsonConvert.DeserializeObject<User>(response.Content);
            User userToCompare = JsonHandler.GetTestDataFromJson<User>("UserToCompare.json");
            Assert.IsTrue(JsonHandler.CompareTwoObjects(user, userToCompare));
        }
    }
}