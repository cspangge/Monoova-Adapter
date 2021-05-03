using System.Collections.Generic;

namespace MonoovaAdapter.Entities.MAccount.Dto
{
    public class MAccountDetails
    {
        public string AccountNumber { get; set; }
        
        public string Name { get; set; }
        
        public string Abn { get; set; }
        
        public string ContactName { get; set; }
        
        public string ContactNumber { get; set; }
        
        public string Email { get; set; }
        
        public string AddressLine1 { get; set; }
        
        public string AddressLine2 { get; set; }
        
        public string Suburb { get; set; }
        
        public string State { get; set; }
        
        public string PostCode { get; set; }
        
        public string Bsb { get; set; }
        
        public string BankAccountNumber { get; set; }
        
        public string BankAccountTitle { get; set; }
        
        public bool AllowDuplicates { get; set; }
        
        public string FeeAccount { get; set; }
        
        public List<MAccountFinancials> Financials { get; set; }
        
        public List<OptionItem> Options { get; set; }
    }
}