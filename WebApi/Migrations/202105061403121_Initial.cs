namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReceivePayments",
                c => new
                    {
                        TransactionId = c.String(nullable: false, maxLength: 128),
                        DateTime = c.String(),
                        RemitterName = c.String(),
                        Amount = c.String(),
                        AccountName = c.String(),
                        AccountNumber = c.String(),
                        Bsb = c.String(),
                        PaymentDescription = c.String(),
                        PayId = c.String(),
                        PayIdName = c.String(),
                        SourceBsb = c.String(),
                        SourceAccountNumber = c.String(),
                        SourceAccountName = c.String(),
                        EndToEndId = c.String(),
                        CategoryPurposeCode = c.String(),
                        CreditorReferenceInformation = c.String(),
                        UsiNumber = c.String(),
                        UsiScheme = c.String(),
                        UltimateCreditorName = c.String(),
                    })
                .PrimaryKey(t => t.TransactionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ReceivePayments");
        }
    }
}
