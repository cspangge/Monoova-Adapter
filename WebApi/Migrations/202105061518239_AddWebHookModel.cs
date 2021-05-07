namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWebHookModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbBankDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Bsb = c.String(),
                        AccountNumber = c.String(),
                        AccountName = c.String(),
                        Token = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DbDirectCreditDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DbReceiveInboundDirectCreditsId = c.Guid(nullable: false),
                        TransactionId = c.String(),
                        BatchId = c.String(),
                        DateTime = c.String(),
                        Bsb = c.String(),
                        AccountNumber = c.String(),
                        AccountName = c.String(),
                        TransactionCode = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LodgementRef = c.String(),
                        RemitterName = c.String(),
                        NameOfUserSupplyingFile = c.String(),
                        NumberOfUserSupplyingFile = c.String(),
                        DescriptionOfEntriesOnFile = c.String(),
                        Indicator = c.String(),
                        WithholdingTaxAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SourceBsb = c.String(),
                        SourceAccountNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbReceiveInboundDirectCredits", t => t.DbReceiveInboundDirectCreditsId, cascadeDelete: true)
                .Index(t => t.DbReceiveInboundDirectCreditsId);
            
            CreateTable(
                "dbo.DbReceiveInboundDirectCredits",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TotalCount = c.Int(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DbDirectDebitDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DbReceiveInboundDirectDebitsId = c.Guid(nullable: false),
                        TransactionId = c.String(),
                        BatchId = c.String(),
                        DateTime = c.String(),
                        Status = c.String(),
                        RespondBeforeDateTime = c.String(),
                        Bsb = c.String(),
                        AccountNumber = c.String(),
                        AccountName = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LodgementRef = c.String(),
                        RemitterName = c.String(),
                        NameOfUserSupplyingFile = c.String(),
                        NumberOfUserSupplyingFile = c.String(),
                        DescriptionOfEntriesOnFile = c.String(),
                        Indicator = c.String(),
                        WithholdingTaxAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbReceiveInboundDirectDebits", t => t.DbReceiveInboundDirectDebitsId, cascadeDelete: true)
                .Index(t => t.DbReceiveInboundDirectDebitsId);
            
            CreateTable(
                "dbo.DbReceiveInboundDirectDebits",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TotalCount = c.Int(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DbReceiveDirectEntryDishonours",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DbBankDetailId = c.Guid(nullable: false),
                        ReturnDate = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Type = c.String(),
                        ReturnReason = c.String(),
                        TransactionDate = c.String(),
                        OriginalTransactionId = c.Int(nullable: false),
                        TransactionReference = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbBankDetails", t => t.DbBankDetailId, cascadeDelete: true)
                .Index(t => t.DbBankDetailId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DbReceiveDirectEntryDishonours", "DbBankDetailId", "dbo.DbBankDetails");
            DropForeignKey("dbo.DbDirectDebitDetails", "DbReceiveInboundDirectDebitsId", "dbo.DbReceiveInboundDirectDebits");
            DropForeignKey("dbo.DbDirectCreditDetails", "DbReceiveInboundDirectCreditsId", "dbo.DbReceiveInboundDirectCredits");
            DropIndex("dbo.DbReceiveDirectEntryDishonours", new[] { "DbBankDetailId" });
            DropIndex("dbo.DbDirectDebitDetails", new[] { "DbReceiveInboundDirectDebitsId" });
            DropIndex("dbo.DbDirectCreditDetails", new[] { "DbReceiveInboundDirectCreditsId" });
            DropTable("dbo.DbReceiveDirectEntryDishonours");
            DropTable("dbo.DbReceiveInboundDirectDebits");
            DropTable("dbo.DbDirectDebitDetails");
            DropTable("dbo.DbReceiveInboundDirectCredits");
            DropTable("dbo.DbDirectCreditDetails");
            DropTable("dbo.DbBankDetails");
        }
    }
}
