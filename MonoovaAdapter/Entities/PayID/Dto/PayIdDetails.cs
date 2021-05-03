namespace MonoovaAdapter.Entities.PayID.Dto
{
    public class PayIdDetails
    {
        public long BankAccountNumber { get; set; }
        
        public string PayId { get; set; }
        
        public string PayIdName { get; set; }
        
        public string PayIdStatus { get; set; }
    }
}