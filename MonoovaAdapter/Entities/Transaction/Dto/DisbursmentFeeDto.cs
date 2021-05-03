namespace MonoovaAdapter.Entities.Transaction.Dto
{
    public class DisbursmentFeeDto
    {
        public int DisbursementArrayIndex { get; set; }
        
        public FeeDetailDto DisbursementFee { get; set; }
    }
}