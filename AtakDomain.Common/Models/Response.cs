using Newtonsoft.Json;

namespace AtakDomain.Common.Models
{
    public class Response
    {
        [JsonProperty("user-id")]
        public string UserId { get; set; }

        public List<string> Products { get; set; }
        public string Type { get; set; }
    }
}