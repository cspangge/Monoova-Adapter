namespace MonoovaAdapter.Entities.Automatcher
{
    public class ProcessDirectDebitResponse : ResponseBase
    {
        public string UniqueReferenced { get; set; }
        
        public int TransactionId { get; set; }
        
        public decimal FeeAmountExcludingGst { get; set; }
        
        public decimal FeeAmountGstComponent { get; set; }
        
        public decimal FeeAmountIncludingGst { get; set; }
    }
}