namespace MonoovaAdapter.Entities.Reports.Dto
{
    public class GenericPaymentSettlementItem
    {
        public string UniqueReferenced { get; set; }
        
        public int TransactionId { get; set; }
        
        public decimal DisbursementAmount { get; set; }
        
        public string DisbursementMethod { get; set; }

        public decimal FeeAmountExclGst { get; set; }
        
        public decimal FeeAmountGstComponent { get; set; }
        
        public decimal FeeAmountInclGst { get; set; }
    }
}