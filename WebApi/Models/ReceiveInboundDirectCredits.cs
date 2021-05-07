using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class ReceiveInboundDirectCredits
    {
        public int TotalCount { get; set; }
        
        public decimal TotalAmount { get; set; }
        
        public List<DirectCreditDetail> DirectCreditDetails { get; set; }
    }
}