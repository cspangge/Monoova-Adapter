using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.PayID
{
    public class PayIdEnquiryResponse : ResponseBase
    {
        public long BankAccountNumber { get; set; }
        
        public string LastResolutionDateTime { get; set; }
        
        public string LastUpdatedDateTime { get; set; }
        
        public string PayIdName { get; set; }
        
        public string RegistrationDateTime { get; set; }
        
        [JsonProperty("Status")]
        public string status { get; set; }
    }
}