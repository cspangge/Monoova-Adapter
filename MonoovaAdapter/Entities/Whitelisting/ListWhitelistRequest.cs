using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Whitelisting
{
    public class ListWhitelistRequest
    {
        [JsonProperty("automatcherBankAccountNumber")]
        public long AutomatcherBankAccountNumber { get; set; }
    }
}