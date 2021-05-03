using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Subscriptions
{
    public class UpdateWebhookRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("targetUrl")]
        public string TargetUrl { get; set; }
        
        [JsonProperty("subscriptionStatus")]
        public string SubscriptionStatus { get; set; }
        
        [JsonProperty("securityToken")]
        public string SecurityToken { get; set; }
    }
}