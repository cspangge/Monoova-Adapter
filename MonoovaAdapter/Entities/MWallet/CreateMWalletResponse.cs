using MonoovaAdapter.Entities.MWallet.Dto;

namespace MonoovaAdapter.Entities.MWallet
{
    public class CreateMWalletResponse : ResponseBase
    {
        public string AccountNumber { get; set; }
        
        public MWalletDetails MWallet { get; set; }
    }
}