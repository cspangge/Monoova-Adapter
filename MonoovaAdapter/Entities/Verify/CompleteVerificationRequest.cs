using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Verify
{
    public class CompleteVerificationRequest
    {
        [JsonProperty("token")]
        public string Token { get; set; }
        
        [JsonProperty("amount")]
        public double Amount { get; set; }
        
        [JsonProperty("code")]
        public int Code { get; set; }
    }
}