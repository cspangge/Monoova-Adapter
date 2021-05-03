using System.Collections.Generic;
using MonoovaAdapter.Entities.MAccount.Dto;

namespace MonoovaAdapter.Entities.MAccount
{
    public class GetTransactionsByMAccountResponse : ResponseBase
    {
        public decimal OpeningBalance { get; set; }
        
        public decimal ClosingBalance { get; set; }
        
        public decimal TotalDebits { get; set; }
        
        public decimal TotalCredits { get; set; }
        
        public List<MAccountTransactionLineItem> Items { get; set; }
    }
}