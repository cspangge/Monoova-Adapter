using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.PayID
{
    public class PayIdEnquiryRequest
    {
        [JsonProperty("payId")]
        public string PayId { get; set; }
    }
}