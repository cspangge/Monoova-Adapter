using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Subscriptions
{
    public class SubscribeWebhookRequest
    {
        [JsonProperty("eventName")]
        public string EventName { get; set; }
        
        [JsonProperty("targetUrl")]
        public string TargetUrl { get; set; }
        
        [JsonProperty("subscriptionStatus")]
        public string SubscriptionStatus { get; set; }
        
        [JsonProperty("securityToken")]
        public string SecurityToken { get; set; }
    }
}