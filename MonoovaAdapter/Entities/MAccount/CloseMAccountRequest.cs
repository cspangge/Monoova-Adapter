using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.MAccount
{
    public class CloseMAccountRequest
    {
        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }
    }
}