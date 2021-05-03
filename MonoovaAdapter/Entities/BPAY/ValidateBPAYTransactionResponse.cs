using MonoovaAdapter.Entities.BPAY.Dto;

namespace MonoovaAdapter.Entities.BPAY
{
    public class ValidateBpayTransactionResponse : ResponseBase
    {
        public BpayValidation Validation { get; set; }
    }
}