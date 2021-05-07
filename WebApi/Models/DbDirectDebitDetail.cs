using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class DbDirectDebitDetail
    {
        [ForeignKey("DbReceiveInboundDirectDebits")]
        public Guid DbReceiveInboundDirectDebitsId { get; set; }
        public DbReceiveInboundDirectDebits DbReceiveInboundDirectDebits { get; set; }
        
        [Key]
        public string TransactionId { get; set; }
        public string BatchId { get; set; }
        public string DateTime { get; set; }
        public string Status { get; set; }
        public string RespondBeforeDateTime { get; set; }
        public string Bsb { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public decimal Amount { get; set; }
        public string LodgementRef { get; set; }
        public string RemitterName { get; set; }
        public string NameOfUserSupplyingFile { get; set; }
        public string NumberOfUserSupplyingFile { get; set; }
        public string DescriptionOfEntriesOnFile { get; set; }
        public string Indicator { get; set; }
        public decimal WithholdingTaxAmount { get; set; }
    }
}