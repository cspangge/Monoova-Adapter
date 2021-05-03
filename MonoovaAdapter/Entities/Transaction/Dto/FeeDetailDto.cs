namespace MonoovaAdapter.Entities.Transaction.Dto
{
    public class FeeDetailDto
    {
        // The fee amount excluding GST
        public decimal FeeAmountExcludingGst { get; set; }
        
        // The GST component of the fee
        public decimal FeeAmountGstComponent { get; set; }
        
        // The fee amount including GST
        public decimal FeeAmountIncludingGst { get; set; }
    }
}