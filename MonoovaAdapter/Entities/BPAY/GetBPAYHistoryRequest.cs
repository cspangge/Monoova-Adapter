namespace MonoovaAdapter.Entities.BPAY
{
    public class GetBpayHistoryRequest
    {
        public long AccountNumber { get; set; }
        
        public int Take { get; set; }
    }
}