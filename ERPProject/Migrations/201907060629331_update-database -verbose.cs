namespace ERPProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabaseverbose : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MenuItems", "ParentMenuItemId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MenuItems", "ParentMenuItemId", c => c.Int(nullable: false));
        }
    }
}
