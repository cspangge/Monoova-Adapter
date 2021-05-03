using System;
using MonoovaAdapter.Entities.Transaction.Dto;

namespace MonoovaAdapter.Entities.Transaction
{
    public class TransactionResponse
    {
        public long DurationMs { get; set; }
        
        public string Status { get; set; }
        
        public string StatusDescription { get; set; }
        
        public int TransactionId { get; set; }
        
        public decimal FeeAmountExcludingGst { get; set; }
        
        public decimal FeeAmountGstComponent { get; set; }
        
        public decimal FeeAmountIncludingGst { get; set; }
        
        public string CallerUniqueReference { get; set; }
        
        public FeeBreakdownDto FeeBreakdown { get; set; }
    }
}