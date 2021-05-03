using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Reports
{
    public class GetAllSuccessfulTransactionsByDateRequest
    {
        [JsonProperty("date")]
        public string Date { get; set; }
    }
}