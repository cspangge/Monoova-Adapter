namespace MonoovaAdapter.Entities.Verify.Dto
{
    public class VerifyAccountDetailsDto
    {
        public string Token { get; set; }
        
        public string Created { get; set; }
        
        public string Updated { get; set; }
        
        public string LastSystemBsbValidation { get; set; }
        
        public string Comment { get; set; }
        
        public string Bsb { get; set; }
        
        public long BankAccountNumber { get; set; }
        
        public string BankAccountTitle { get; set; }
        
        public string Remitter { get; set; }
        
        public bool IsBlacklisted { get; set; }
        
        public bool HasDDAuthority { get; set; }
        
        public string DdAuthorityChangedTimestamp { get; set; }
        
        public string DdAuthorityChangedBy { get; set; }
        
        public string VerificationIdentifier { get; set; }
        
        public string VerificationStatus { get; set; }
        
        public string VerificationSignonMerchant { get; set; }
        
        public int VerificationRetryCount { get; set; }
        
        public int VerificationRetyCountBeforeLockout { get; set; }
        
        public string VerificationLastRetryTimestamp { get; set; }
        
        public int VerificationLastRetryLockoutMinutes { get; set; }
        
        public int VerificationDEJobId { get; set; }
        
        public int VerificationRootId { get; set; }
    }
}