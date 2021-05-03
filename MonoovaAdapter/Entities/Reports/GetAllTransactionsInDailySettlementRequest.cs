using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Reports
{
    public class GetAllTransactionsInDailySettlementRequest
    {
        [JsonProperty("date")]
        public string Date { get; set; }
    }
}