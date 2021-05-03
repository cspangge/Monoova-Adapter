namespace MonoovaAdapter.Entities.Transaction
{
    public class RefundRequest
    {
        public string UniqueReference { get; set; }
        
        public decimal RefundAmount { get; set; }
        
        public string Description { get; set; }
        
        public long OriginalTransactionId { get; set; }
    }
}