using System.ComponentModel.DataAnnotations;

namespace MonoovaAdapter.Entities.Transaction.Disbursement
{
    public class NppCreditPayIdDetail
    {
        [Required(ErrorMessage = "PayId is required")]
        [MaxLength(256, ErrorMessage = "Max length is 256")]
        public string PayId { get; set; }
        
        [Required(ErrorMessage = "PayId Type is required")]
        public PayIdType PayIdType { get; set; }
        
        [Required(ErrorMessage = "Account Name is required")]
        [MinLength(2, ErrorMessage = "Minimum length is 2")]
        public string AccountName { get; set; }
        
        [MaxLength(35, ErrorMessage = "Max length is 35")]
        public string EndToEndId { get; set; }
        
        [MaxLength(140, ErrorMessage = "Max length is 140")]
        public string RemitterName { get; set; }
    }
}