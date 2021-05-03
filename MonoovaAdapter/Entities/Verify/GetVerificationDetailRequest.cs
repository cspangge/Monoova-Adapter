using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Verify
{
    public class GetVerificationDetailRequest
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}