namespace ERPProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MAccountingYears : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountingYears",
                c => new
                    {
                        AccountingYearId = c.Long(nullable: false, identity: true),
                        AccountingYearName = c.String(),
                        FromDate = c.DateTime(nullable: false),
                        ToDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AccountingYearId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AccountingYears");
        }
    }
}
