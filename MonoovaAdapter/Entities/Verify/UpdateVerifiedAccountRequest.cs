using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Verify
{
    public class UpdateVerifiedAccountRequest
    {
        [JsonProperty("token")]
        public string Token { get; set; }
        
        [JsonProperty("remitter")]
        public string Remitter { get; set; }
        
        [JsonProperty("verificationIdentifier")]
        public string VerificationIdentifier { get; set; }
        
        [JsonProperty("hasDDAuthority")]
        public bool HasDdAuthority { get; set; }
        
        [JsonProperty("bankAccountTitle")]
        public string BankAccountTitle { get; set; }
    }
}