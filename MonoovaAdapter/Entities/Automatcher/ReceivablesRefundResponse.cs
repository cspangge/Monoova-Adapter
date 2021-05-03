namespace MonoovaAdapter.Entities.Automatcher
{
    public class ReceivablesRefundResponse : ResponseBase
    { 
        public string CallerUniqueReference { get; set; }
        
        public decimal FeeAmountExcludingGst { get; set; }
        
        public decimal FeeAmountGstComponent { get; set; }
        
        public decimal FeeAmountIncludingGst { get; set; }
        
        public int TransactionId { get; set; }
    }
}