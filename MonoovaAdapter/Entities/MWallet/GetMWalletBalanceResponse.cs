using MonoovaAdapter.Entities.MWallet.Dto;

namespace MonoovaAdapter.Entities.MWallet
{
    public class GetMWalletBalanceResponse : ResponseBase
    {
        public MWalletFinancials Financials { get; set; }
    }
}