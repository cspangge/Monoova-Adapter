using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.MAccount.Dto
{
    public class SendSettlementStatement
    {
        [JsonProperty("key")]
        public string Key { get; set; } = "SendSettlementStatement";

        [JsonProperty("value")]
        public bool Value { get; set; } = true;
    }
}