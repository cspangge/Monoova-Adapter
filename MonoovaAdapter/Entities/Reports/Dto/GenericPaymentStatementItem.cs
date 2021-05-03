namespace MonoovaAdapter.Entities.Reports.Dto
{
    public class GenericPaymentStatementItem
    {
        public string UniqueReferenced { get; set; }
        
        public int TransactionId { get; set; }
        
        public string DateTime { get; set; }
        
        public string Status { get; set; }
        
        public decimal TotalAmount { get; set; }
        
        public decimal FeeAmountExcludingGst { get; set; }
        
        public decimal FeeAmountGstComponent { get; set; }
        
        public decimal FeeAmountIncludingGst { get; set; }
    }
}