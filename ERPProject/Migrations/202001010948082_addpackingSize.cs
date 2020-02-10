namespace ERPProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpackingSize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PackingSizes",
                c => new
                    {
                        PackingSizeId = c.Long(nullable: false, identity: true),
                        packingSizeName = c.String(),
                        PackingSizeCapacity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PackingSizeId);
            
            AddColumn("dbo.SaleBillDetail", "PackingSizeId", c => c.Long(nullable: false));
            CreateIndex("dbo.SaleBillDetail", "PackingSizeId");
            AddForeignKey("dbo.SaleBillDetail", "PackingSizeId", "dbo.PackingSizes", "PackingSizeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaleBillDetail", "PackingSizeId", "dbo.PackingSizes");
            DropIndex("dbo.SaleBillDetail", new[] { "PackingSizeId" });
            DropColumn("dbo.SaleBillDetail", "PackingSizeId");
            DropTable("dbo.PackingSizes");
        }
    }
}
