namespace WebApi.Models
{
    public class ReceiveDirectEntryDishonours
    {
        public string ReturnDate { get; set; }
        public decimal Amount { get; set; }
        public BankDetail BankDetails { get; set; }
        public string Type { get; set; }
        public string ReturnReason { get; set; }
        public string TransactionDate { get; set; }
        public int OriginalTransactionId { get; set; }
        public string TransactionReference { get; set; }
    }
}