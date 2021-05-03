using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Automatcher
{
    public class ProcessDirectDebitRequest
    {
        [JsonProperty("transactionId")]
        public string TransactionId { get; set; }
        
        [JsonProperty("response")]
        public string Response { get; set; }
        
        [JsonProperty("rejectionReason")]
        public string RejectionReason { get; set; }
        
        [JsonProperty("returnCode")]
        public string ReturnCode { get; set; }
    }
}