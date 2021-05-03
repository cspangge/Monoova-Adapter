using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.MWallet
{
    public class ResetMWalletPinRequest
    {
        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }
        
        [JsonProperty("pin")]
        public string Pin { get; set; }
        
        [JsonProperty("dateOfBirth")]
        public string DateOfBirth { get; set; }
    }
}