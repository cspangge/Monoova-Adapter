using Newtonsoft.Json;

namespace MonoovaAdapter.Entities
{
    public class KeyValuePair
    {
        [JsonProperty("key")]
        public string Key { get; set; }
        
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}