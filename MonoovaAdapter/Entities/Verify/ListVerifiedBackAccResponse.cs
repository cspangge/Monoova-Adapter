using System.Collections.Generic;
using MonoovaAdapter.Entities.Verify.Dto;

namespace MonoovaAdapter.Entities.Verify
{
    public class ListVerifiedBackAccResponse
    {
        public long DurationMs { get; set; }
        
        public string Status { get; set; }
        
        public string StatusDescription { get; set; }
        
        public List<VerifyAccountDetailsDto> List { get; set; }
    }
}