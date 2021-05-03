using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Tools
{
    public class EmailIssuerRequest
    {
        [JsonProperty("subject")]
        public string Subject { get; set; }
        
        [JsonProperty("isBodyHtml")]
        public bool IsBodyHtml { get; set; }
        
        [JsonProperty("body")]
        public string Body { get; set; }
    }
}