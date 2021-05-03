namespace MonoovaAdapter.Entities.BPAY.Dto
{
    public class BpayValidation
    {
        public string BillerCode { get; set; }
        
        public string CustomerReferenceNumber { get; set; }
        
        public string Amount { get; set; }
        
        public string BillerName { get; set; }
        
        public bool IsVariableCrn { get; set; }
        
        public decimal MinimumPaymentAmount { get; set; }
        
        public decimal MaximumPaymentAmount { get; set; }
    }
}