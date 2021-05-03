namespace MonoovaAdapter.Entities.MWallet.Dto
{
    public class MWalletTransactionLineItem
    {
        public int RowOrder { get; set; }
        
        public int MPaymentsId { get; set; }
        
        public int TransactionId { get; set; }
        
        public string DateTime { get; set; }
        
        public string MAccountName { get; set; }
        
        public string TransactionType { get; set; }
        
        public string SubTransactionType { get; set; }
        
        public decimal Credit { get; set; }
        
        public decimal Debit { get; set; }
        
        public decimal RunningBalance { get; set; }
        
        public string Description { get; set; }
    }
}