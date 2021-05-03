using MonoovaAdapter.Entities.Whitelisting.Dto;

namespace MonoovaAdapter.Entities.Whitelisting
{
    public class UpdateWhitelistResponse : ResponseBase
    {
        public long AutomatcherBankAccountNumber { get; set; }
        
        public SourceAccountUpdate SourceAccount { get; set; }
    }
}