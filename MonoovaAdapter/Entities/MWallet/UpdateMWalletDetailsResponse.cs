using MonoovaAdapter.Entities.MWallet.Dto;

namespace MonoovaAdapter.Entities.MWallet
{
    public class UpdateMWalletDetailsResponse : ResponseBase
    {
        public MWalletDetails MWallet { get; set; }
    }
}