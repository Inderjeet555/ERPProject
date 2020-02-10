namespace ERPProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Taxclass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaxClass",
                c => new
                    {
                        TaxId = c.Long(nullable: false, identity: true),
                        Taxname = c.String(),
                        TaxRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.TaxId);
            
            AddColumn("dbo.SaleBillDetail", "TaxClassId", c => c.Long(nullable: false));
            CreateIndex("dbo.SaleBillDetail", "TaxClassId");
            AddForeignKey("dbo.SaleBillDetail", "TaxClassId", "dbo.TaxClass", "TaxId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaleBillDetail", "TaxClassId", "dbo.TaxClass");
            DropIndex("dbo.SaleBillDetail", new[] { "TaxClassId" });
            DropColumn("dbo.SaleBillDetail", "TaxClassId");
            DropTable("dbo.TaxClass");
        }
    }
}
