namespace ERPProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class schoolDb1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AccUserRoles", "UserId", "dbo.AccUser");
            DropForeignKey("dbo.SaleBillDetail", "ItemId", "dbo.Items");
            DropForeignKey("dbo.SaleBillDetail", "SaleBillHeaderid", "dbo.SaleBillHeader");
            DropForeignKey("dbo.SaleBillHeader", "PartyAccountId", "dbo.Accounts");
            DropForeignKey("dbo.SaleBillHeader", "VoucherHeaderId", "dbo.VoucherHeaders");
            DropForeignKey("dbo.VoucherHeaders", "VoucherAccountID", "dbo.Accounts");
            DropIndex("dbo.VoucherHeaders", new[] { "VoucherAccountID" });
            AlterColumn("dbo.VoucherHeaders", "VoucherAccountID", c => c.Long());
            CreateIndex("dbo.VoucherHeaders", "VoucherAccountID");
            AddForeignKey("dbo.AccUserRoles", "UserId", "dbo.AccUser", "Id");
            AddForeignKey("dbo.SaleBillDetail", "ItemId", "dbo.Items", "ItemId");
            AddForeignKey("dbo.SaleBillDetail", "SaleBillHeaderid", "dbo.SaleBillHeader", "SaleBillHeaderid");
            AddForeignKey("dbo.SaleBillHeader", "PartyAccountId", "dbo.Accounts", "AccountId");
            AddForeignKey("dbo.SaleBillHeader", "VoucherHeaderId", "dbo.VoucherHeaders", "VoucherHeaderID");
            AddForeignKey("dbo.VoucherHeaders", "VoucherAccountID", "dbo.Accounts", "AccountId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VoucherHeaders", "VoucherAccountID", "dbo.Accounts");
            DropForeignKey("dbo.SaleBillHeader", "VoucherHeaderId", "dbo.VoucherHeaders");
            DropForeignKey("dbo.SaleBillHeader", "PartyAccountId", "dbo.Accounts");
            DropForeignKey("dbo.SaleBillDetail", "SaleBillHeaderid", "dbo.SaleBillHeader");
            DropForeignKey("dbo.SaleBillDetail", "ItemId", "dbo.Items");
            DropForeignKey("dbo.AccUserRoles", "UserId", "dbo.AccUser");
            DropIndex("dbo.VoucherHeaders", new[] { "VoucherAccountID" });
            AlterColumn("dbo.VoucherHeaders", "VoucherAccountID", c => c.Long(nullable: false));
            CreateIndex("dbo.VoucherHeaders", "VoucherAccountID");
            AddForeignKey("dbo.VoucherHeaders", "VoucherAccountID", "dbo.Accounts", "AccountId", cascadeDelete: true);
            AddForeignKey("dbo.SaleBillHeader", "VoucherHeaderId", "dbo.VoucherHeaders", "VoucherHeaderID", cascadeDelete: true);
            AddForeignKey("dbo.SaleBillHeader", "PartyAccountId", "dbo.Accounts", "AccountId", cascadeDelete: true);
            AddForeignKey("dbo.SaleBillDetail", "SaleBillHeaderid", "dbo.SaleBillHeader", "SaleBillHeaderid", cascadeDelete: true);
            AddForeignKey("dbo.SaleBillDetail", "ItemId", "dbo.Items", "ItemId", cascadeDelete: true);
            AddForeignKey("dbo.AccUserRoles", "UserId", "dbo.AccUser", "Id", cascadeDelete: true);
        }
    }
}
