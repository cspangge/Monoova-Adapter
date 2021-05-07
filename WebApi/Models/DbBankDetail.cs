using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class DbBankDetail
    {
        [Key]
        public Guid Id { get; set; } 
        
        [ForeignKey("DbReceiveDirectEntryDishonours")]
        public Guid DbReceiveDirectEntryDishonoursId { get; set; }
        public DbReceiveDirectEntryDishonours DbReceiveDirectEntryDishonours { get; set; }
        
        public string Bsb { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string Token { get; set; }
    }
}