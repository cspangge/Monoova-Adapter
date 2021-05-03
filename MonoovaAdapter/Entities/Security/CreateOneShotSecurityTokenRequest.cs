using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Security
{
    public class CreateOneShotSecurityTokenRequest
    {
        [JsonProperty("timeOutMin")]
        public int TimeOutMin { get; set; }
        
        [JsonProperty("TokenClaims")]
        public string TokenClaims { get; set; }
    }
}