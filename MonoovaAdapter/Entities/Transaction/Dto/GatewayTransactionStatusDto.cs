namespace MonoovaAdapter.Entities.Transaction.Dto
{
    public class GatewayTransactionStatusDto
    {
        public string UniqueReference { get; set; }
        
        public string StatusDescription { get; set; }
        
        public string TransactionStatus { get; set; }
        
        public string DishonouredDate { get; set; }
        
        public string CreditCardPaymentStatus { get; set; }
    }
}