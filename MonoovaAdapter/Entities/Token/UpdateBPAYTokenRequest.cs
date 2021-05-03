namespace MonoovaAdapter.Entities.Token
{
    public class UpdateBpayTokenRequest
    {
        public string AccountNumber { get; set; }
        
        public string TokenToUpdate { get; set; }
        
        public string Description { get; set; }
        
        public string BillerCode { get; set; }
        
        public string CustomerReferenceNumber { get; set; }
        
        public decimal Amount { get; set; }
    }
}