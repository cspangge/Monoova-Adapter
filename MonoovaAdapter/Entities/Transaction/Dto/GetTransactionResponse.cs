namespace MonoovaAdapter.Entities.Transaction.Dto
{
    public class GetTransactionResponse
    {
        public long DurationMs { get; set; }
        
        public string Status { get; set; }
        
        public string StatusDescription { get; set; }
        
        public string CreditCardPaymentStatus { get; set; }
        
        public string DishonouredDate { get; set; }
        
        public string ExpectedClearanceDateForFunds { get; set; }
        
        public string FundsClearedDate { get; set; }
        
        public string TransactionStatus { get; set; }
        
        public string UniqueReference { get; set; }
    }
}