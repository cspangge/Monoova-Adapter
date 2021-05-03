using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.MAccount.Dto
{
    public class DebitTplusXDays
    {
        [JsonProperty("key")]
        public string Key { get; set; } = "DebitTplusXDays";

        [JsonProperty("value")]
        public int Value { get; set; } = 0;
    }
}