using Newtonsoft.Json;

namespace RestAPITesting.Models
{
    public class Post
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("body")]
        public string Body { get; set; }

        public Post(int userId, string title, string body)
        {
            UserId = userId;
            Title = title;
            Body = body;
        }
    }
}
