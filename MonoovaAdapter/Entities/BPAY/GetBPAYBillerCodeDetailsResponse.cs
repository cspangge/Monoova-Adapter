using MonoovaAdapter.Entities.BPAY.Dto;

namespace MonoovaAdapter.Entities.BPAY
{
    public class GetBpayBillerCodeDetailsResponse : ResponseBase
    {
        public BpayBiller Biller { get; set; }
    }
}