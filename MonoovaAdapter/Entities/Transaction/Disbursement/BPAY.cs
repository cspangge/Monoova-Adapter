using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Transaction.Disbursement
{
    public class Bpay
    {
        [Required(ErrorMessage = "Disbursement Method is required")]
        [JsonProperty("disbursementMethod")]
        public string DisbursementMethod { get; set; } = "BPAY";
        
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "BPay Detail is required")]
        [JsonProperty("toBPayDetails")]
        public BPayDetail ToBPayDetails { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
    }
}