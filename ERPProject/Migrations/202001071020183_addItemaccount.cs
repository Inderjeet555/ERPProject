namespace ERPProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addItemaccount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "SaleAccountId", c => c.Long());
            AddColumn("dbo.Items", "PurchaseAccountId", c => c.Long(nullable: false));
            CreateIndex("dbo.Items", "PurchaseAccountId");
            AddForeignKey("dbo.Items", "PurchaseAccountId", "dbo.Accounts", "AccountId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "PurchaseAccountId", "dbo.Accounts");
            DropIndex("dbo.Items", new[] { "PurchaseAccountId" });
            DropColumn("dbo.Items", "PurchaseAccountId");
            DropColumn("dbo.Items", "SaleAccountId");
        }
    }
}
