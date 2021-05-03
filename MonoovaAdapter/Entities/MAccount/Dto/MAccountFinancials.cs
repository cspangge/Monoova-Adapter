namespace MonoovaAdapter.Entities.MAccount.Dto
{
    public class MAccountFinancials
    {
        public string AccountNumber { get; set; }
        
        public decimal ActualBalance { get; set; }
        
        public bool ClearedFundsOnly { get; set; }
        
        public long CreditLimit { get; set; }
        
        public decimal FeeAccountActualBalance { get; set; }
        
        public string FeeAccountNumber { get; set; }
        
        public bool HasSeparateFeeAccount { get; set; }
        
        public decimal LowerCreditLimit { get; set; }
        
        public decimal MinimumSettlementAmount { get; set; }
        
        public string SettlementFrequency { get; set; }
        
        public long UpperCreditLimit { get; set; }
        
        public bool IsFeeAccount { get; set; }
        
        public bool IsParentAccount { get; set; }
        
        public bool IsParentClearedFunds { get; set; }
        
        public MAccountClearedFundsAccount ClearedFundsAccountFinancials { get; set; }
    }
}