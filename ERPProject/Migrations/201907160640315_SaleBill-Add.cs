namespace ERPProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SaleBillAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountId = c.Long(nullable: false, identity: true),
                        AccountName = c.String(),
                        GSTNo = c.String(),
                        PAN = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.AccountId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Long(nullable: false, identity: true),
                        ItemName = c.String(),
                        ItemCategory = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId);
            
            CreateTable(
                "dbo.SaleBillDetail",
                c => new
                    {
                        SaleBillDetailId = c.Long(nullable: false, identity: true),
                        SaleBillHeaderid = c.Long(nullable: false),
                        ItemId = c.Long(nullable: false),
                        Description = c.String(),
                        Bags = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxableAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CGSTAmount = c.Decimal(precision: 18, scale: 2),
                        CGSTPer = c.Decimal(precision: 18, scale: 2),
                        SGSTAmount = c.Decimal(precision: 18, scale: 2),
                        SGSTPer = c.Decimal(precision: 18, scale: 2),
                        IGSTAmount = c.Decimal(precision: 18, scale: 2),
                        IGSTPer = c.Decimal(precision: 18, scale: 2),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GSTRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.SaleBillDetailId)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: false)
                .ForeignKey("dbo.SaleBillHeader", t => t.SaleBillHeaderid, cascadeDelete: false)
                .Index(t => t.SaleBillHeaderid)
                .Index(t => t.ItemId);

            CreateTable(
                "dbo.SaleBillHeader",
                c => new
                    {
                        SaleBillHeaderid = c.Long(nullable: false, identity: true),
                        PartyAccountId = c.Long(nullable: false),
                        MyProperty = c.Int(nullable: false),
                        InvoiceNo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        VoucherHeaderId = c.Long(nullable: false),
                       
                    })
                .PrimaryKey(t => t.SaleBillHeaderid)
                .ForeignKey("dbo.Accounts", t => t.PartyAccountId, cascadeDelete: false)
                .ForeignKey("dbo.VoucherHeaders", t => t.VoucherHeaderId, cascadeDelete: false)
                .Index(t => t.PartyAccountId)
                .Index(t => t.VoucherHeaderId);
                
            
            CreateTable(
                "dbo.VoucherHeaders",
                c => new
                    {
                        VoucherHeaderID = c.Long(nullable: false, identity: true),
                        RecordHeaderID = c.Long(nullable: false),
                        HistoryHeaderID = c.Long(nullable: false),
                        VoucherTypeSeriesID = c.Long(nullable: false),
                        VoucherNo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VoucherDate = c.DateTime(nullable: false),
                        VoucherAccountID = c.Long(nullable: false),
                        Version = c.Binary(),
                        GrainMarketID = c.Long(),
                    })
                .PrimaryKey(t => t.VoucherHeaderID)
                .ForeignKey("dbo.Accounts", t => t.VoucherAccountID, cascadeDelete: false)
                .Index(t => t.VoucherAccountID);
            
            CreateTable(
                "dbo.VoucherDetail",
                c => new
                    {
                        VoucherDetailID = c.Long(nullable: false, identity: true),
                        VoucherHeaderID = c.Long(nullable: false),
                        AccountID = c.Long(nullable: false),
                        SAccountID = c.Long(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BillNo = c.String(),
                        InstrumentNo = c.String(),
                        InstrumentDate = c.DateTime(),
                        InstrumentDesc = c.String(),
                        ClearingDate = c.DateTime(),
                        Narration = c.String(),
                        Version = c.Binary(),
                    })
                .PrimaryKey(t => t.VoucherDetailID)
                .ForeignKey("dbo.Accounts", t => t.SAccountID)
                .ForeignKey("dbo.VoucherHeaders", t => t.VoucherHeaderID, cascadeDelete: true)
                .Index(t => t.VoucherHeaderID)
                .Index(t => t.SAccountID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaleBillHeader", "VoucherHeaderId", "dbo.VoucherHeaders");
            DropForeignKey("dbo.VoucherDetail", "VoucherHeaderID", "dbo.VoucherHeaders");
            DropForeignKey("dbo.VoucherDetail", "SAccountID", "dbo.Accounts");
            DropForeignKey("dbo.SaleBillHeader", "VoucherHeaders_VoucherHeaderID", "dbo.VoucherHeaders");
            DropForeignKey("dbo.VoucherHeaders", "VoucherAccountID", "dbo.Accounts");
            DropForeignKey("dbo.SaleBillDetail", "SaleBillHeaderid", "dbo.SaleBillHeader");
            DropForeignKey("dbo.SaleBillHeader", "PartyAccountId", "dbo.Accounts");
            DropForeignKey("dbo.SaleBillDetail", "ItemId", "dbo.Items");
            DropIndex("dbo.VoucherDetail", new[] { "SAccountID" });
            DropIndex("dbo.VoucherDetail", new[] { "VoucherHeaderID" });
            DropIndex("dbo.VoucherHeaders", new[] { "VoucherAccountID" });
            DropIndex("dbo.SaleBillHeader", new[] { "VoucherHeaders_VoucherHeaderID" });
            DropIndex("dbo.SaleBillHeader", new[] { "VoucherHeaderId" });
            DropIndex("dbo.SaleBillHeader", new[] { "PartyAccountId" });
            DropIndex("dbo.SaleBillDetail", new[] { "ItemId" });
            DropIndex("dbo.SaleBillDetail", new[] { "SaleBillHeaderid" });
            DropTable("dbo.VoucherDetail");
            DropTable("dbo.VoucherHeaders");
            DropTable("dbo.SaleBillHeader");
            DropTable("dbo.SaleBillDetail");
            DropTable("dbo.Items");
            DropTable("dbo.Accounts");
        }
    }
}
