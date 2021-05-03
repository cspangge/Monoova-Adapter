using MonoovaAdapter.Entities.Whitelisting.Dto;
using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Whitelisting
{
    public class UpdateWhitelistRequest
    {
        [JsonProperty("automatcherBankAccountNumber")]
        public long AutomatcherBankAccountNumber { get; set; }
        
        [JsonProperty("sourceAccount")]
        public SourceAccountUpdate SourceAccount { get; set; }
    }
}