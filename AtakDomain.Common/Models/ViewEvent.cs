using Newtonsoft.Json;

namespace AtakDomain.Common.Models
{
    public class ViewEvent
    {
        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("messageid")]
        public string MessageId { get; set; }

        [JsonProperty("userid")]
        public string UserId { get; set; }

        [JsonProperty("properties")]
        public Properties Properties { get; set; }

        [JsonProperty("context")]
        public Context Context { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
    }

    public class Properties
    {
        [JsonProperty("productid")]
        public string ProductId { get; set; }
    }

    public class Context
    {
        [JsonProperty("source")]
        public string Source { get; set; }
    }
}