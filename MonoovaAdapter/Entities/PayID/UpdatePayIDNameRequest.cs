using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.PayID
{
    public class UpdatePayIdNameRequest
    {
        [JsonProperty("bankAccountNumber")]
        public long BankAccountNumber { get; set; }

        [JsonProperty("payIdName")]
        public string PayIdName { get; set; }
        
        [JsonProperty("payId")]
        public string PayId { get; set; }
    }
}