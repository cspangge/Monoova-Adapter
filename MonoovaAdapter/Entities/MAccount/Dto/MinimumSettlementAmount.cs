using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.MAccount.Dto
{
    public class MinimumSettlementAmount
    {
        [JsonProperty("key")]
        public string Key { get; set; } = "MinimumSettlementAmount";
        
        [JsonProperty("value")]
        public decimal Value { get; set; }
    }
}