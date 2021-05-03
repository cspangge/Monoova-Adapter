using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Automatcher
{
    public class BatchCreateRequest
    {
        [JsonProperty("content")]
        public byte[] Content { get; set; }
    }
}