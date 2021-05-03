namespace MonoovaAdapter.Entities.Token
{
    public class CreateBpayTokenRequest
    {
        public string AccountNumber { get; set; }

        public string Description { get; set; }
        
        public string BillerCode { get; set; }
        
        public string CustomerReferenceNumber { get; set; }
        
        public decimal Amount { get; set; }
    }
}