using MonoovaAdapter.Entities.Verify.Dto;

namespace MonoovaAdapter.Entities.Verify
{
    public class GetVerificationDetailResponse
    {
        public long DurationMs { get; set; }
        
        public string Status { get; set; }
        
        public string StatusDescription { get; set; }
        
        public VerifyAccountDetailsDto Details { get; set; }
    }
}