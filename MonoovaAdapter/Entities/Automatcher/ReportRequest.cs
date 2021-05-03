using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Automatcher
{
    public class ReportRequest
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        public string EndDate { get; set; } = "";

        public int Skip { get; set; } = 0;

        public int Take { get; set; } = 1000;

        public long AccountNumber { get; set; }

        public string ClientUniqueId { get; set; }

        public string TransactionType { get; set; }

        public int TransactionCode { get; set; }
    }
}