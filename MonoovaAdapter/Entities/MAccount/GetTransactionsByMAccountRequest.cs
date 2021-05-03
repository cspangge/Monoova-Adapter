using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.MAccount
{
    public class GetTransactionsByMAccountRequest
    {
        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }
        
        [JsonProperty("frequency")]
        public string Frequency { get; set; }
        
        [JsonProperty("startDate")]
        public string StartDate { get; set; }
        
        [JsonProperty("endDate")]
        public string EndDate { get; set; }
        
        [JsonProperty("descending")]
        public bool Descending { get; set; }
        
        [JsonProperty("useTime")]
        public bool UseTime { get; set; }
    }
}