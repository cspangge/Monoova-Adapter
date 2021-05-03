using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.MAccount.Dto
{
    public class SettlementFrequency
    {
        [JsonProperty("key")]
        public string Key { get; set; } = "SettlementFrequency";

        [JsonProperty("value")]
        public string Value { get; set; } = SettlementType.Daily.ToString();
    }
}