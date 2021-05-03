namespace MonoovaAdapter.Entities.Tools
{
    public class ValidateBsbResponse : ResponseBase
    {
        public string Bsb { get; set; }
        
        public string Closed { get; set; }
        
        public string Address { get; set; }
        
        public string City { get; set; }
        
        public string State { get; set; }
        
        public string PostCode { get; set; }
        
        public string BankCode { get; set; }
    }
}