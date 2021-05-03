using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Transaction
{
    public class TransactionRequestMAccount : TransactionRequest
    {
        [Required(ErrorMessage = "MAccount is required")]
        [JsonProperty("mAccount")]
        public MAccount MAccount { get; set; }
    }
}