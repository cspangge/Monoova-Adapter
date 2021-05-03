using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Verify
{
    public class InitiateRequest
    {
        [JsonProperty("creditMethod")]
        public string CreditMethod { get; set; }
        
        [JsonProperty("bsb")]
        public string Bsb { get; set; }
        
        [JsonProperty("bankAccountNumber")]
        public string BankAccountNumber { get; set; }
        
        [JsonProperty("accountName")]
        public string AccountName { get; set; }
        
        [JsonProperty("remitter")]
        public string Remitter { get; set; }
        
        [JsonProperty("payIdType")]
        public string PyIdType { get; set; }
        
        [JsonProperty("payId")]
        public string PayId { get; set; }
        
        [JsonProperty("verificationIdentifier")]
        public string VerificationIdentifier { get; set; }
    }
}