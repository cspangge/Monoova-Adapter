using System.Collections.Generic;

namespace MonoovaAdapter.Entities.MWallet.Dto
{
    public class MWalletDetails
    {
        public string CreatedDateTime { get; set; }
        
        public string AccountNumber { get; set; }
        
        public string Name { get; set; }
        
        public string NickName { get; set; }
        
        public string Email { get; set; }
        
        public string Mobile { get; set; }
        
        public string LastTransactionDate { get; set; }
        
        public string ContactPhone { get; set; }
        
        public string AuthenticationEmail { get; set; }
        
        public string AuthenticationMobile { get; set; }
        
        public string AuthenticationLandLine { get; set; }
        
        public string RegisteredByMAccountNumber { get; set; }
        
        public bool IsOnHold { get; set; }
        
        public bool IsClosed { get; set; }
        
        public bool IsStolen { get; set; }
        
        public bool IsRegistered { get; set; }
        
        public MWalletFinancials Financials { get; set; }
        
        public List<MWalletOptionItem> Options { get; set; }
    }
}