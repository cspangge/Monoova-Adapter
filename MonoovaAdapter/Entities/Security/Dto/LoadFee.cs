namespace MonoovaAdapter.Entities.Security.Dto
{
    public class LoadFee
    {
        public string Method { get; set; }
        
        public string CardType { get; set; }
        
        public string DebitFromMAccount { get; set; }
        
        public string FeePercentageExGst { get; set; }
        
        public string FeeFixedExGst { get; set; }
    }
}