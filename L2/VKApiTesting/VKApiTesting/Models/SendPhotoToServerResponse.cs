using Newtonsoft.Json;

namespace VKApiTesting.Models.SendToServer
{
    public class SendPhotoToServerResponse
    {
        [JsonProperty("server")]
        public int Server { get; set; }

        [JsonProperty("photos_list")]
        public string PhotosList { get; set; }

        [JsonProperty("aid")]
        public int Aid { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }
    }
}
