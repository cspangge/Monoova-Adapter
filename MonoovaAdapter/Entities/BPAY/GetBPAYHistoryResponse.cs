using System.Collections.Generic;
using MonoovaAdapter.Entities.BPAY.Dto;

namespace MonoovaAdapter.Entities.BPAY
{
    public class GetBpayHistoryResponse : ResponseBase
    {
        public List<BPayHistoryItem> History { get; set; }
    }
}