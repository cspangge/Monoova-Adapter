using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Transaction
{
    public class MAccount
    {
        [StringLength(16)]
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}