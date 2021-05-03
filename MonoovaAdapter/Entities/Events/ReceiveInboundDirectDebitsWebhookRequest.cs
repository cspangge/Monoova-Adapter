using System.Collections.Generic;
using MonoovaAdapter.Entities.Events.Dto;

namespace MonoovaAdapter.Entities.Events
{
    public class ReceiveInboundDirectDebitsWebhookRequest
    {
        public int TotalCount { get; set; }
        
        public decimal TotalAmount { get; set; }
        
        public List<DirectDebitDetails> DirectDebitDetails { get; set; }
    }
}