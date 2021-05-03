using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Transaction.Disbursement
{
    public class AbaToken
    {
        [Required(ErrorMessage = "Disbursement Method is required")]
        [JsonProperty("disbursementMethod")]
        public string DisbursementMethod { get; set; } = "token";
        
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "ToToken is required")]
        [JsonProperty("toToken")]
        public string ToToken { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        
        [RegularExpression(@"^[a-zA-Z0-9 \.\(\+\$\*\)\^\[\];\-\/,%_?:#@'=&!]*$")]
        [MaxLength(18, ErrorMessage = "Max length is 18")]
        [JsonProperty("lodgementReference")]
        public string LodgementReference { get; set; }
    }
}