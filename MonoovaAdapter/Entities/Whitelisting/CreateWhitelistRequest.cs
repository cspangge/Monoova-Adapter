using MonoovaAdapter.Entities.Whitelisting.Dto;
using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Whitelisting
{
    public class CreateWhitelistRequest
    {
        [JsonProperty("automatcherBankAccountNumber")]
        public long AutomatcherBankAccountNumber { get; set; }
        
        [JsonProperty("sourceAccount")]
        public SourceAccountUpdate SourceAccount { get; set; }
    }
}