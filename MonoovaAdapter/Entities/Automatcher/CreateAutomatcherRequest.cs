using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Automatcher
{
    public class CreateAutomatcherRequest
    {
        [JsonProperty("bankAccountName")]
        public string BankAccountName { get; set; }
        
        [JsonProperty("clientUniqueId")]
        public string ClientUniqueId { get; set; }

        [JsonProperty("isActive")] 
        public bool IsActive { get; set; } = false;
    }
}