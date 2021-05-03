using System.Collections.Generic;
using MonoovaAdapter.Entities.MWallet.Dto;

namespace MonoovaAdapter.Entities.MWallet
{
    public class MWalletSearchResponse : ResponseBase
    {
        public List<MWalletDetails> MWallets { get; set; }
    }
}