using System.Collections.Generic;
using MonoovaAdapter.Entities.MWallet.Dto;

namespace MonoovaAdapter.Entities.MWallet
{
    public class GetTransactionsByMWalletResponse : ResponseBase
    {
        public decimal OpeningBalance { get; set; }
        
        public decimal ClosingBalance { get; set; }
        
        public decimal TotalDebits { get; set; }
        
        public decimal TotalCredits { get; set; }
        
        public List<MWalletTransactionLineItem> Items { get; set; }
    }
}