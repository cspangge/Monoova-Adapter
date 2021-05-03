using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Transaction
{
    public class TransactionRequestDirectDebit : TransactionRequest
    {
        [Required(ErrorMessage = "DirectDebit is required")]
        [JsonProperty("directDebit")]
        public DirectDebit DirectDebit { get; set; }
    }
}