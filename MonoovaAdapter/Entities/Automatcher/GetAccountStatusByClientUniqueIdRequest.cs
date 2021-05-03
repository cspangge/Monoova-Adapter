using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Automatcher
{
    public class GetAccountStatusByClientUniqueIdRequest
    {
        [JsonProperty("clientUniqueId")]
        public string ClientUniqueId { get; set; }
    }
}