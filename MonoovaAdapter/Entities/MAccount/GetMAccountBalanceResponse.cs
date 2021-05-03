using MonoovaAdapter.Entities.MAccount.Dto;

namespace MonoovaAdapter.Entities.MAccount
{
    public class GetMAccountBalanceResponse : ResponseBase
    {
        public MAccountFinancials Financials { get; set; }
    }
}