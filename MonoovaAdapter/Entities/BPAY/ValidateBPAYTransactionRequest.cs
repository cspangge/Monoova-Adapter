namespace MonoovaAdapter.Entities.BPAY
{
    public class ValidateBpayTransactionRequest
    {
        public string BillerCode { get; set; }
        
        public string CustRef { get; set; }
        
        public decimal Amount { get; set; }
    }
}