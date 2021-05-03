namespace MonoovaAdapter.Entities.MAccount.Dto
{
    public class MAccountTransactionLineItem
    {
        public decimal Credit { get; set; }
        
        public string DateTime { get; set; }
        
        public decimal Debit { get; set; }
        
        public string Description { get; set; }
        
        public bool IsWaitingForFundsToClear { get; set; }
        
        public long MPaymentsId { get; set; }
        
        public string MWalletAccountNumber { get; set; }
        
        public int RowOrder { get; set; }
        
        public decimal RunningBalance { get; set; }
        
        public string SubTransactionType { get; set; }
        
        public string TransactionDescription { get; set; }
        
        public long TransactionId { get; set; }
        
        public string TransactionType { get; set; }
        
        public string UniqueReference { get; set; }
    }
}