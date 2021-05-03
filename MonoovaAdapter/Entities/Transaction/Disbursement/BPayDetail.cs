using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Transaction.Disbursement
{
    public class BPayDetail
    {
        [Required(ErrorMessage = "Biller Code is required")]
        [JsonProperty("billerCode")]
        public int BillerCode { get; set; }
        
        [Required(ErrorMessage = "Reference Number is required")]
        [JsonProperty("referenceNumber")]
        public long ReferenceNumber { get; set; }
    }
}