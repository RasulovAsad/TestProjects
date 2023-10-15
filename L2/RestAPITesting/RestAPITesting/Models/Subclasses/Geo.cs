using Newtonsoft.Json;

namespace RestAPITesting.Models.Subclasses
{
    public class Geo
    {
        [JsonProperty("lat")]
        public string Latitude { get; set; }

        [JsonProperty("lng")]
        public string Longtitude { get; set; }
    }
}
