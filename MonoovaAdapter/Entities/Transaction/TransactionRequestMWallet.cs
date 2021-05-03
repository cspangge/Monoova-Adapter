using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Transaction
{
    public class TransactionRequestMWallet : TransactionRequest
    {
        [Required(ErrorMessage = "MWallet is required")]
        [JsonProperty("mWallet")]
        public MWallet MWallet { get; set; }
    }
}