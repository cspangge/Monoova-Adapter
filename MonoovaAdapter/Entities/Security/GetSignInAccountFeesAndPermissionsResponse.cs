using System.Collections.Generic;
using MonoovaAdapter.Entities.Security.Dto;

namespace MonoovaAdapter.Entities.Security
{
    public class GetSignInAccountFeesAndPermissionsResponse : ResponseBase
    {
        public List<DisbursementFee> DisbursementFees { get; set; }
        
        public List<LoadFee> LoadFees { get; set; }
        
        public bool CanDebitCreditCards { get; set; }
        
        public bool CanPayBpay { get; set; }
        
        public bool CanImpersonate { get; set; }
        
        public bool CanDirectDebit { get; set; }
        
        public bool CanDirectCredit { get; set; }
        
        public bool CanCreateMAccounts { get; set; }
        
        public bool CanCreateMWallets { get; set; }
        
        public bool CanAccessUserDatabase { get; set; }
        
        public bool IsIssuer { get; set; }
        
        public string IssuerMAccountNumber { get; set; }
        
        public string MonthlyFeeExGst { get; set; }
        
        public string ClearingMAccountNumber { get; set; }
        
        public string FeeMAccountNumber { get; set; }
        
        public string FeeMAccountMonthlyFeeExGst { get; set; }
        
        public string ChildMAccountSetUpFeeExGst { get; set; }
        
        public string ChildMAccountMonthlyFeeExGst { get; set; }
        
        public bool RequiresClearedFundsOnly { get; set; }
    }
}