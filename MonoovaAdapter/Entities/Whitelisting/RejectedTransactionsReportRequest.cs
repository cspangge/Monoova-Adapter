using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Whitelisting
{
    public class RejectedTransactionsReportRequest
    {
        [JsonProperty("date")]
        public string Date { get; set; }
    }
}