using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Whitelisting.Dto
{
    public class SourceAccountUpdate : SourceAccount
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}