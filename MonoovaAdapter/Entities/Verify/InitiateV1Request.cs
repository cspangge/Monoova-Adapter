using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Verify
{
    public class InitiateV1Request
    {
        [MaxLength(7)]
        [JsonProperty("bsb")]
        public string Bsb { get; set; }
        
        [MaxLength(9)]
        [JsonProperty("bankAccountNumber")]
        public string BankAccountNumber { get; set; }
        
        [MaxLength(32)]
        [JsonProperty("bankAccountTitle")]
        public string BankAccountTitle { get; set; }
        
        [MaxLength(16)]
        [JsonProperty("remitter")]
        public string Remitter { get; set; }
        
        [MaxLength(512)]
        [JsonProperty("verificationIdentifier")]
        public string VerificationIdentifier { get; set; }

        [JsonProperty("hasDDAuthority")]
        public bool HasDdAuthority { get; set; } = true;
    }
}