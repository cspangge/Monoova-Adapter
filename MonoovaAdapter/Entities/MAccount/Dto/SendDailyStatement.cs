using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.MAccount.Dto
{
    public class SendDailyStatement
    {
        [JsonProperty("key")]
        public string Key { get; set; } = "SendDailyStatement";

        [JsonProperty("value")]
        public bool Value { get; set; } = true;
    }
}