using System.Collections.Generic;
using MonoovaAdapter.Entities.Events.Dto;

namespace MonoovaAdapter.Entities.Events
{
    public class ReceiveInboundDirectCreditsWebhookRequest
    {
        public int TotalCount { get; set; }
        
        public decimal TotalAmount { get; set; }
        
        public List<DirectCreditDetails> DirectCreditDetails { get; set; }
    }
}