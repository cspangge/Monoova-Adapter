using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.MWallet
{
    public class MWalletSearchRequest
    {
        [JsonProperty("identifier")]
        public string Identifier { get; set; }
    }
}