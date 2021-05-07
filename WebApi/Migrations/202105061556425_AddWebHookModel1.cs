namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWebHookModel1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.DbDirectCreditDetails");
            AlterColumn("dbo.DbDirectCreditDetails", "TransactionId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.DbDirectCreditDetails", "TransactionId");
            DropColumn("dbo.DbDirectCreditDetails", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DbDirectCreditDetails", "Id", c => c.Guid(nullable: false));
            DropPrimaryKey("dbo.DbDirectCreditDetails");
            AlterColumn("dbo.DbDirectCreditDetails", "TransactionId", c => c.String());
            AddPrimaryKey("dbo.DbDirectCreditDetails", "Id");
        }
    }
}
