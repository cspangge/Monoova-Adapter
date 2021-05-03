using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Transaction.Disbursement
{
    public class NppCreditBankAccount
    {
        [Required(ErrorMessage = "Disbursement Method is required")]
        [JsonProperty("disbursementMethod")]
        public string DisbursementMethod { get; set; } = "toNppCreditBankAccountDetails";
        
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("toNppCreditBankAccountDetails")]
        public NppCreditBankAccountDetail ToNppCreditBankAccountDetails { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        
        [MaxLength(280, ErrorMessage = "Max length is 280")]
        [JsonProperty("lodgementReference")]
        public string LodgementReference { get; set; }
    }
}