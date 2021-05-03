using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.MAccount.Dto
{
    public class SendMonthlyStatement
    {
        [JsonProperty("key")]
        public string Key { get; set; } = "SendMonthlyStatement";

        [JsonProperty("value")]
        public bool Value { get; set; } = true;
    }
}