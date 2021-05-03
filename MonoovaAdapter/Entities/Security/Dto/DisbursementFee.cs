namespace MonoovaAdapter.Entities.Security.Dto
{
    public class DisbursementFee
    {
        public string Method { get; set; }
        
        public string FeePercentageExGst { get; set; }
        
        public string FeeFixedExGst { get; set; }
    }
}