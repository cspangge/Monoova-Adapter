using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.PayID
{
    public class UpdatePayIdStatusRequest
    {
        [JsonProperty("bankAccountNumber")]
        public long BankAccountNumber { get; set; }

        [JsonProperty("payId")]
        public string PayId { get; set; }
        
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}