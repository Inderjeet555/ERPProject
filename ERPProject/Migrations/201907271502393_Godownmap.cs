namespace ERPProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Godownmap : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Godowns",
                c => new
                    {
                        GodownId = c.Long(nullable: false, identity: true),
                        GodownName = c.String(),
                        GodownAddress = c.String(),
                        City = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GodownId);
            
            AddColumn("dbo.SaleBillHeader", "SaleOrderNo", c => c.Long(nullable: false));
            AddColumn("dbo.SaleBillHeader", "TotalAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.SaleBillHeader", "FreightAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.SaleBillHeader", "Taxamount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.SaleBillHeader", "Narration", c => c.String());
            AddColumn("dbo.SaleBillHeader", "DiscountAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.SaleBillHeader", "GodownId", c => c.Long(nullable: false));
            CreateIndex("dbo.SaleBillHeader", "GodownId");
            AddForeignKey("dbo.SaleBillHeader", "GodownId", "dbo.Godowns", "GodownId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaleBillHeader", "GodownId", "dbo.Godowns");
            DropIndex("dbo.SaleBillHeader", new[] { "GodownId" });
            DropColumn("dbo.SaleBillHeader", "GodownId");
            DropColumn("dbo.SaleBillHeader", "DiscountAmount");
            DropColumn("dbo.SaleBillHeader", "Narration");
            DropColumn("dbo.SaleBillHeader", "Taxamount");
            DropColumn("dbo.SaleBillHeader", "FreightAmount");
            DropColumn("dbo.SaleBillHeader", "TotalAmount");
            DropColumn("dbo.SaleBillHeader", "SaleOrderNo");
            DropTable("dbo.Godowns");
        }
    }
}
