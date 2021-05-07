namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWebHookModel2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.DbDirectDebitDetails");
            AlterColumn("dbo.DbDirectDebitDetails", "TransactionId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.DbDirectDebitDetails", "TransactionId");
            DropColumn("dbo.DbDirectDebitDetails", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DbDirectDebitDetails", "Id", c => c.Guid(nullable: false));
            DropPrimaryKey("dbo.DbDirectDebitDetails");
            AlterColumn("dbo.DbDirectDebitDetails", "TransactionId", c => c.String());
            AddPrimaryKey("dbo.DbDirectDebitDetails", "Id");
        }
    }
}
