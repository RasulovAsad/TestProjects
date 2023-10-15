using Newtonsoft.Json;

namespace VKApiTesting.Models.Post
{
    public class WallPostResponse
    {
        [JsonProperty("response")]
        public Response Response { get; set; }
    }

    public class Response
    {
        [JsonProperty("post_id")]
        public int PostId { get; set; }
    }
}

