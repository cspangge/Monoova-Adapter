namespace MonoovaAdapter.Entities.Events.Dto
{
    public class BankDetails
    {
        public string Bsb { get; set; }
        
        public string AccountNumber { get; set; }
        
        public string AccountName { get; set; }
        
        public string Token { get; set; }
    }
}