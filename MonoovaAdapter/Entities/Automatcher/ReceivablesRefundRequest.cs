using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Automatcher
{
    public class ReceivablesRefundRequest
    {
        [JsonProperty("uniqueReference")]
        public string UniqueReferenced { get; set; }
        
        [JsonProperty("originalTransactionId")]
        public string OriginalTransactionId { get; set; }
        
        [JsonProperty("refundAmount")]
        public decimal RefundAmount { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("refundReference")]
        public string RefundReference { get; set; }
    }
}