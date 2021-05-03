using System.Collections.Generic;

namespace MonoovaAdapter.Entities.Transaction.Dto
{
    public class GetTransactionByDateResponse
    {
        public long DurationMs { get; set; }
        
        public string Status { get; set; }
        
        public string StatusDescription { get; set; }
        
        public List<GatewayTransactionStatusDto> Statuses { get; set; }
    }
}