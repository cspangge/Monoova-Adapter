namespace MonoovaAdapter.Entities.BPAY.Dto
{
    public class BPayHistoryItem
    {
        public long BillerCode { get; set; }
        
        public long CustomerReferenceNumber { get; set; }
        
        public long BillerName { get; set; }
        
        public int Count { get; set; }
    }
}