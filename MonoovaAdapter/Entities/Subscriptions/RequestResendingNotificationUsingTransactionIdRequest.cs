using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Subscriptions
{
    public class RequestResendingNotificationUsingTransactionIdRequest
    {
        [JsonProperty("transactionId")]
        public long TransactionId { get; set; }
        
        [JsonProperty("eventName")]
        public string EventName { get; set; }
    }
}