using System.Collections.Generic;

namespace MonoovaAdapter.Entities.MAccount.Dto
{
    public class MAccountClearedFundsAccount
    {
        public decimal AvailableBalance { get; set; }
        
        public decimal UnclearedFunds { get; set; }
        
        public List<string> UniqueReferencesWaitingToClear { get; set; }
    }
}