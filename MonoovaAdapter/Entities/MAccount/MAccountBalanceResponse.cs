using MonoovaAdapter.Entities.MAccount.Dto;

namespace MonoovaAdapter.Entities.MAccount
{
    public class MAccountBalanceResponse
    {
        public long DurationMs { get; set; }
        
        public string Status { get; set; }
        
        public string StatusDescription { get; set; }
        
        public MAccountFinancials Financials { get; set; }
    }
}