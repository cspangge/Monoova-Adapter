namespace MonoovaAdapter.Entities.Transaction
{
    public class RefundResponse
    {
        public string CallerUniqueReference { get; set; }
        
        public decimal FeeAmountExcludingGst { get; set; }
        
        public decimal FeeAmountGstComponent { get; set; }
        
        public decimal FeeAmountIncludingGst { get; set; }
        
        public long TransactionId { get; set; }
        
        public string Status { get; set; }
        
        public string StatusDescription { get; set; }
        
        public long DurationMs { get; set; }
    }
}