using MonoovaAdapter.Entities.Events.Dto;

namespace MonoovaAdapter.Entities.Events
{
    public class ReceiveDirectEntryDishonoursWebhookRequest
    {
        public string ReturnDate { get; set; }
        
        public decimal Amount { get; set; }
        
        public BankDetails BankDetails { get; set; }
        
        public string Type { get; set; }
        
        public string ReturnReason { get; set; }
        
        public string TransactionDate { get; set; }
        
        public long OriginalTransactionId { get; set; }
        
        public string TransactionReference { get; set; }
    }
}