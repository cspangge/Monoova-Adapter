using Newtonsoft.Json;

namespace MonoovaAdapter.Entities
{
    public class ResponseBase
    {
        [JsonProperty("durationMs")]
        public long DurationMs { get; set; }
        
        [JsonProperty("status")]
        public string Status { get; set; }
        
        [JsonProperty("statusDescription")]
        public string StatusDescription { get; set; }
    }
}