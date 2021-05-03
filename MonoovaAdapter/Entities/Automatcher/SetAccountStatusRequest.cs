using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Automatcher
{
    public class SetAccountStatusRequest
    {
        [MinLength(9)]
        [JsonProperty("bankAccountName")]
        public string BankAccountNumber { get; set; }
        
        [MinLength(10)]
        [MaxLength(35)]
        [JsonProperty("clientUniqueId")]
        public string ClientUniqueId { get; set; }

        [JsonProperty("isActive")] 
        public bool IsActive { get; set; } = true;
    }
}