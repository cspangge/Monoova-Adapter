namespace MonoovaAdapter.Entities.BPAY.Dto
{
    public class BpayBiller
    {
        public string BillerCode { get; set; }
        
        public string BillerLongName { get; set; }
        
        public string BillerShortName { get; set; }
        
        public string AcceptedPaymentMethods { get; set; }
        
        public string ActivationDate { get; set; }
        
        public string DeactivationDate { get; set; }
        
        public decimal MinPaymentAmount { get; set; }
        
        public decimal MaxPaymentAmount { get; set; }
        
        public string CrnValidationRuleName { get; set; }
        
        public string CheckDigitRuleName { get; set; }
        
        public string LengthMask { get; set; }
        
        public string FixedDigits { get; set; }
        
        public bool IsVariableCrn { get; set; }
    }
}