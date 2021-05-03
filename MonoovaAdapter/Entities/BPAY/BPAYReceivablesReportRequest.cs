using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.BPAY
{
    public class BpayReceivablesReportRequest
    {
        [JsonProperty("date")]
        public string Date { get; set; }
        
        public int Skip { get; set; }
        
        public int Take { get; set; }
    }
}