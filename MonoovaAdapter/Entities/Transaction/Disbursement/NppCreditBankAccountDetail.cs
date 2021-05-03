using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Transaction.Disbursement
{
    public class NppCreditBankAccountDetail
    {
        [Required(ErrorMessage = "Bsb Number is required")]
        [JsonProperty("bsbNumber")]
        public string BsbNumber { get; set; }
        
        [Required(ErrorMessage = "Account Number is required")]
        [Range(100, 999999999, ErrorMessage = "Range of '100' to '999999999'")]
        [JsonProperty("accountNumber")]
        public int AccountNumber { get; set; }
        
        [Required(ErrorMessage = "Account Name is required")]
        [MinLength(2, ErrorMessage = "Minimum length is 2")]
        [JsonProperty("accountName")]
        public string AccountName { get; set; }
        
        [MaxLength(35, ErrorMessage = "Max length is 35")]
        [JsonProperty("endToEndId")]
        public string EndToEndId { get; set; }
        
        [MaxLength(140, ErrorMessage = "Max length is 140")]
        [JsonProperty("remitterName")]
        public string RemitterName { get; set; }
    }
}