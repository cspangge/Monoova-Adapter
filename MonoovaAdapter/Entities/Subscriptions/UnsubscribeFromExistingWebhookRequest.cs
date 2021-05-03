using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Subscriptions
{
    public class UnsubscribeFromExistingWebhookRequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}