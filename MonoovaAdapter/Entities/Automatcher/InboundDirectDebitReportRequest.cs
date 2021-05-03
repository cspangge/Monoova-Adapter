using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Automatcher
{
    public class InboundDirectDebitReportRequest
    {
        [JsonProperty("date")]
        public string Date { get; set; }
    }
}