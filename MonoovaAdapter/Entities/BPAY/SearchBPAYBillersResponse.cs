using System.Collections.Generic;
using MonoovaAdapter.Entities.BPAY.Dto;

namespace MonoovaAdapter.Entities.BPAY
{
    public class SearchBpayBillersResponse : ResponseBase
    {
        public string Search { get; set; }
        
        public int TotalCount { get; set; }
        
        public int Skip { get; set; }
        
        public int Take { get; set; }
        
        public List<BpayBiller> Billers { get; set; }
    }
}