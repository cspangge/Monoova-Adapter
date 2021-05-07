namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWebHookModel3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DbReceiveDirectEntryDishonours", "DbBankDetailId", "dbo.DbBankDetails");
            DropIndex("dbo.DbReceiveDirectEntryDishonours", new[] { "DbBankDetailId" });
            AddColumn("dbo.DbBankDetails", "DbReceiveDirectEntryDishonoursId", c => c.Guid(nullable: false));
            CreateIndex("dbo.DbBankDetails", "DbReceiveDirectEntryDishonoursId");
            AddForeignKey("dbo.DbBankDetails", "DbReceiveDirectEntryDishonoursId", "dbo.DbReceiveDirectEntryDishonours", "Id", cascadeDelete: true);
            DropColumn("dbo.DbReceiveDirectEntryDishonours", "DbBankDetailId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DbReceiveDirectEntryDishonours", "DbBankDetailId", c => c.Guid(nullable: false));
            DropForeignKey("dbo.DbBankDetails", "DbReceiveDirectEntryDishonoursId", "dbo.DbReceiveDirectEntryDishonours");
            DropIndex("dbo.DbBankDetails", new[] { "DbReceiveDirectEntryDishonoursId" });
            DropColumn("dbo.DbBankDetails", "DbReceiveDirectEntryDishonoursId");
            CreateIndex("dbo.DbReceiveDirectEntryDishonours", "DbBankDetailId");
            AddForeignKey("dbo.DbReceiveDirectEntryDishonours", "DbBankDetailId", "dbo.DbBankDetails", "Id", cascadeDelete: true);
        }
    }
}
