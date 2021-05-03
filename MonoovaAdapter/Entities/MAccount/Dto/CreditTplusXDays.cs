using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.MAccount.Dto
{
    public class CreditTplusXDays
    {
        [JsonProperty("key")]
        public string Key { get; set; } = "CreditTplusXDays";

        [JsonProperty("value")]
        public int Value { get; set; } = 0;
    }
}