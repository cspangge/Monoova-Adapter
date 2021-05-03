using MonoovaAdapter.Entities.Whitelisting.Dto;

namespace MonoovaAdapter.Entities.Whitelisting
{
    public class CreateWhitelistResponse : ResponseBase
    {
        public long AutomatcherBankAccountNumber { get; set; }
        
        public SourceAccount SourceAccount { get; set; }
    }
}