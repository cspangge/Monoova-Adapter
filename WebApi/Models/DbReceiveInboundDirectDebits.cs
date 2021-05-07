using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class DbReceiveInboundDirectDebits
    {
        [Key]
        public Guid Id { get; set; }

        public int TotalCount { get; set; }
        
        public decimal TotalAmount { get; set; }
    }
}