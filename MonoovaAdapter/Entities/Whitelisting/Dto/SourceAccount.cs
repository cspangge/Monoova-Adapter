using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Whitelisting.Dto
{
    public class SourceAccount
    {
        [JsonProperty("accountName")]
        public string AccountName { get; set; }
        
        [JsonProperty("accountNumber")]
        public long AccountNumber { get; set; }
        
        [JsonProperty("accountStatus")]
        public string AccountStatus { get; set; }
        
        [JsonProperty("bsbNumber")]
        public string BsbNumber { get; set; }
    }
}