namespace MonoovaAdapter.Entities.Subscriptions
{
    public class SubscribeWebhookResponse : ResponseBase
    {
        public string Id { get; set; }
        
        public string DateTime { get; set; }
        
        public string EventName { get; set; }
        
        public string TargetUrl { get; set; }
    }
}