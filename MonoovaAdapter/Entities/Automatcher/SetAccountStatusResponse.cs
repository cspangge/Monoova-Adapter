namespace MonoovaAdapter.Entities.Automatcher
{
    public class SetAccountStatusResponse : ResponseBase
    {
        public string Bsb { get; set; }
        
        public long BankAccountNumber { get; set; }
        
        public string BankAccountName { get; set; }
        
        public string ClientUniqueId { get; set; }
        
        public bool IsActive { get; set; }
    }
}