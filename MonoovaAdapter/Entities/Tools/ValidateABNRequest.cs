using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Tools
{
    public class ValidateAbnRequest
    {
        [JsonProperty("abnNumber")]
        public string AbnNumber { get; set; }
    }
}