﻿namespace MonoovaAdapter.Entities.BPAY
{
    public class SearchBpayBillersRequest
    {
        public string Search { get; set; }
        
        public int Skip { get; set; }
        
        public int Take { get; set; }
    }
}