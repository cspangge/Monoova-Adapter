namespace MonoovaAdapter.Entities.Events
{
    public class ReceivePaymentWebhookRequest
    {
        public string TransactionId { get; set; }

        public string DateTime { get; set; }
        
        public string RemitterName { get; set; }
        
        public string Amount { get; set; }
        
        public string AccountName { get; set; }
        
        public string AccountNumber { get; set; }
        
        public string Bsb { get; set; }
        
        public string PaymentDescription { get; set; }
        
        public string PayId { get; set; }
        
        public string PayIdName { get; set; }
        
        public string SourceBsb { get; set; }
        
        public string SourceAccountNumber { get; set; }
        
        public string SourceAccountName { get; set; }
        
        public string EndToEndId { get; set; }
        
        public string CategoryPurposeCode { get; set; }
        
        public string CreditorReferenceInformation { get; set; }
        
        public string UsiNumber { get; set; }
        
        public string UsiScheme { get; set; }
        
        public string UltimateCreditorName { get; set; }
    }
}