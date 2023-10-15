using Newtonsoft.Json;

namespace FinalTask.Models
{
    public class TestModel
    {
        [JsonProperty("duration")]
        public string? Duration { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("startTime")]
        public string StartTime { get; set; }

        [JsonProperty("endTime", NullValueHandling = NullValueHandling.Ignore)]
        public string? EndTime { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
        public string? SessionId { get; set; }
        public string? ProjectName { get; set; }
        public string? Env { get; set; }
        public string? BrowserName { get; set; }

        public TestModel(string method, string name, string startTime, string? sessionId, string? projectName,
            string? env, string? browserName, string? endTime = null, string? duration = null, string status = "InProgress")
        {
            Duration = duration;
            Method = method;
            Name = name;
            StartTime = startTime;
            EndTime = endTime;
            Status = status;
            SessionId = sessionId;
            ProjectName = projectName;
            Env = env;
            BrowserName = browserName;
        }
    }
}
