using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.MAccount
{
    public class GetMAccountDetailsRequest
    {
        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }
    }
}