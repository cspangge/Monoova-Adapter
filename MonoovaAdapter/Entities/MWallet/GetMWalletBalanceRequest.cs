using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.MWallet
{
    public class GetMWalletBalanceRequest
    {
        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }
        
        [JsonProperty("pin")]
        public string Pin { get; set; }
    }
}