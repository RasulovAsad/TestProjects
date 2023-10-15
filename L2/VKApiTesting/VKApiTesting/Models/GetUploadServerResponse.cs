using Newtonsoft.Json;

namespace VKApiTesting.Models.UploadServer
{
    public class GetUploadServerResponse
    {
        [JsonProperty("response")]
        public Response Response { get; set; }
    }

    public class Response
    {
        [JsonProperty("upload_url")]
        public string UploadUrl { get; set; }

        [JsonProperty("user_id")]
        public int UserId { get; set; }
    }
}
