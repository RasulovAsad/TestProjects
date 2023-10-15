using Newtonsoft.Json;

namespace VKApiTesting.Models.Users
{
    public class UsersGetResponse
    {
        [JsonProperty("response")]
        public List<Response> Response { get; set; }
    }

    public class Response
    {
        [JsonProperty("id")]
        public int userId { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("can_access_closed")]
        public bool CanAccessClosed { get; set; }

        [JsonProperty("is_closed")]
        public bool IsClosed { get; set; }
    }
}
