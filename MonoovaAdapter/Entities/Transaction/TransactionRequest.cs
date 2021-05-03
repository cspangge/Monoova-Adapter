using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Transaction
{
    public class TransactionRequest
    {
        [MaxLength(200, ErrorMessage = "Minimum length is 2, Max length is 200")]
        [JsonProperty("uniqueReference")]
        public string UniqueReference { get; set; }

        [JsonProperty("printUniqueReferenceOnStatement")]
        public bool PrintUniqueReferenceOnStatement { get; set; } = false;
        
        [Required(ErrorMessage = "Amount is required")]
        [JsonProperty("totalAmount")]
        [Range(0.01, double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        public decimal TotalAmount { get; set; }
        
        [Required(ErrorMessage = "PaymentSource is required")]
        [JsonProperty("paymentSource")]
        public string PaymentSource { get; set; }

        [MaxLength(500, ErrorMessage = "Max length is 500")]
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("disbursements")]
        public List<object> Disbursements { get; set; }
    }
}