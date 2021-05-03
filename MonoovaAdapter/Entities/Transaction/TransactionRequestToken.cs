using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Transaction
{
    public class TransactionRequestToken : TransactionRequest
    {
        [Required(ErrorMessage = "Token is required")]
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}