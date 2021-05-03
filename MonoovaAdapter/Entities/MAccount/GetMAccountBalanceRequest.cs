using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.MAccount
{
    public class GetMAccountBalanceRequest
    {
        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }
    }
}