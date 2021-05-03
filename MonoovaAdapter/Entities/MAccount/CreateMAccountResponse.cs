namespace MonoovaAdapter.Entities.MAccount
{
    public class CreateMAccountResponse
    {
        public long DurationMs { get; set; }
        
        public string Status { get; set; }
        
        public string StatusDescription { get; set; }
        
        public string AccountNumber { get; set; }
    }
}