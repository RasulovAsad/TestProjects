using Newtonsoft.Json;

namespace VKApiTesting.Models.Likes
{
    public class IsLikedResponse
    {
        [JsonProperty("response")]
        public Response Response { get; set; }
    }

    public class Response
    {
        [JsonProperty("liked")]
        public int Liked { get; set; }

        [JsonProperty("copied")]
        public int Copied { get; set; }
    }
}

