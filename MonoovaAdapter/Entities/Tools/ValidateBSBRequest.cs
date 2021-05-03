using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Tools
{
    public class ValidateBsbRequest
    {
        [JsonProperty("bsbNumber")]
        public string BsbNumber { get; set; }
    }
}