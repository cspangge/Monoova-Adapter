namespace MonoovaAdapter.Entities.Verify
{
    public class InitiateResponse
    {
        public long DurationMs { get; set; }
        
        public string Status { get; set; }
        
        public string StatusDescription { get; set; }
        
        public string Token { get; set; }
        
        public decimal FeeAmountExGst { get; set; }
        
        public decimal FeeAmountIncGst { get; set; }
        
        public decimal FeeAmountGstComp { get; set; }
        
        public string OwnerName { get; set; }
    }
}