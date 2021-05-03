namespace MonoovaAdapter.Entities.Token
{
    public class UpdateBankAccountTokenRequest
    {
        public string AccountNumber { get; set; }
        
        public string TokenToUpdate { get; set; }
        
        public string Description { get; set; }
        
        public string BankAccountName { get; set; }
        
        public long BankAccountNumber { get; set; }
        
        public string Bsb { get; set; }
    }
}