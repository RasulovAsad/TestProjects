using Newtonsoft.Json;

namespace VKApiTesting.Models.Albums
{
    public class GetAlbumsResponse
    {
        [JsonProperty("response")]
        public Response Response { get; set; }
    }

    public class Response
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("items")]
        public List<Item> Items { get; set; }
    }

    public class Item
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("owner_id")]
        public int OwnerId { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("feed_disabled")]
        public int FeedDisabled { get; set; }

        [JsonProperty("feed_has_pinned")]
        public int FeedHasPinned { get; set; }

        [JsonProperty("created")]
        public int Created { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("can_delete")]
        public bool CanDelete { get; set; }

        [JsonProperty("privacy_comment")]
        public Privacy PrivacyComment { get; set; }

        [JsonProperty("privacy_view")]
        public Privacy PrivacyView { get; set; }

        [JsonProperty("thumb_id")]
        public int ThumbId { get; set; }

        [JsonProperty("thumb_is_last")]
        public int ThumbIsLast { get; set; }

        [JsonProperty("updated")]
        public int Updated { get; set; }
    }

    public class Privacy
    {
        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("lists")]
        public Lists Lists { get; set; }

        [JsonProperty("owners")]
        public Lists Owners { get; set; }
    }

    public class Lists
    {
        [JsonProperty("allowed")]
        public List<object> Allowed { get; set; }

        [JsonProperty("excluded")]
        public List<object> Excluded { get; set; }
    }
}
