using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.MWallet
{
    public class ReopenClosedMWalletRequest
    {
        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }
        
        [JsonProperty("pin")]
        public string Pin { get; set; }
    }
}