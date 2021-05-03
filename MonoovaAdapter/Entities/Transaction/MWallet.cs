using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Transaction
{
    public class MWallet
    {
        [StringLength(16)]
        [JsonProperty("token")]
        public string Token { get; set; }
        
        [StringLength(4)]
        [JsonProperty("pin")]
        public string Pin { get; set; }
    }
}