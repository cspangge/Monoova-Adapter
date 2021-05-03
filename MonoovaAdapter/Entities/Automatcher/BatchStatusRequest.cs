using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Automatcher
{
    public class BatchStatusRequest
    {
        [JsonProperty("content")]
        public byte[] Content { get; set; }
    }
}