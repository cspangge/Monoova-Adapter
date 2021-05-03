using System.Collections.Generic;
using MonoovaAdapter.Entities.Whitelisting.Dto;

namespace MonoovaAdapter.Entities.Whitelisting
{
    public class ListWhitelistResponse : ResponseBase
    {
        public long AutomatcherBankAccountNumber { get; set; }
        
        public List<SourceAccountUpdate> SourceAccount { get; set; }
    }
}