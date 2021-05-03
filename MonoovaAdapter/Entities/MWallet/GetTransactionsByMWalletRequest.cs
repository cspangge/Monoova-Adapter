using System;
using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.MWallet
{
    public class GetTransactionsByMWalletRequest
    {
        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }
        
        [JsonProperty("pin")]
        public string Pin { get; set; }
        
        [JsonProperty("startDate")]
        public string StartDate { get; set; }
        
        [JsonProperty("endDate")]
        public string EndDate { get; set; }
        
        [JsonProperty("skip")]
        public int Skip { get; set; }
        
        [JsonProperty("take")]
        public int Take { get; set; }
        
        [JsonProperty("descending")]
        public bool Descending { get; set; }
        
        [JsonProperty("useTime")]
        public bool UseTime { get; set; }
    }
}