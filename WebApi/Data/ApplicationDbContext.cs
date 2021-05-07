using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() :
            base("Monoova")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<ReceivePayment> ReceivePayments { get; set; }
        
        public DbSet<DbReceiveInboundDirectCredits> DbReceiveInboundDirectCredits { get; set; }
        public DbSet<DbReceiveInboundDirectDebits> DbReceiveInboundDirectDebits { get; set; }
        public DbSet<DbReceiveDirectEntryDishonours> DbReceiveDirectEntryDishonours { get; set; }
        
        public DbSet<DbDirectCreditDetail> DbDirectCreditDetails { get; set; }
        public DbSet<DbDirectDebitDetail> DbDirectDebitDetails { get; set; }
        public DbSet<DbBankDetail> DbBankDetails { get; set; }
    }
}