using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Transaction.Disbursement
{
    public class DirectCreditDetail
    {
        [Required(ErrorMessage = "BsbNumber is required")]
        [RegularExpression(@"^\d{3}-\d{3}$")]
        [JsonProperty("bsbNumber")]
        public string BsbNumber { get; set; }
        
        [Required(ErrorMessage = "Account Number is required")]
        [Range(100, 999999999, ErrorMessage = "Range of '100' to '999999999'")]
        [JsonProperty("accountNumber")]
        public int AccountNumber { get; set; }
        
        [Required(ErrorMessage = "Account Name is required")]
        [MinLength(2, ErrorMessage = "Minimum length is 2, Max length is 32")]
        [MaxLength(32, ErrorMessage = "Minimum length is 2, Max length is 32")]
        [JsonProperty("accountName")]
        public string AccountName { get; set; }
    }
}