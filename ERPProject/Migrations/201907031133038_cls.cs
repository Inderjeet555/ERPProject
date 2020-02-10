namespace ERPProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cls : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AccUserRoles", "RoleId", "dbo.Roles");
            CreateTable(
                "dbo.Capabilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CapabilityName = c.String(),
                        MenuItemId = c.Int(nullable: false),
                        AccessType = c.Int(nullable: false),
                        Restrictions = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MenuItems", t => t.MenuItemId)
                .Index(t => t.MenuItemId);
            
            CreateTable(
                "dbo.MenuItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuItemName = c.String(),
                        Url = c.String(),
                        ParentMenuItemId = c.Int(nullable: false),
                        DisplaySequence = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoleCapabilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        CapabilityId = c.Int(nullable: false),
                        AccessFlag = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Capabilities", t => t.CapabilityId)
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .Index(t => t.RoleId)
                .Index(t => t.CapabilityId);
            
            AddForeignKey("dbo.AccUserRoles", "RoleId", "dbo.Roles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccUserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.RoleCapabilities", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.RoleCapabilities", "CapabilityId", "dbo.Capabilities");
            DropForeignKey("dbo.Capabilities", "MenuItemId", "dbo.MenuItems");
            DropIndex("dbo.RoleCapabilities", new[] { "CapabilityId" });
            DropIndex("dbo.RoleCapabilities", new[] { "RoleId" });
            DropIndex("dbo.Capabilities", new[] { "MenuItemId" });
            DropTable("dbo.RoleCapabilities");
            DropTable("dbo.MenuItems");
            DropTable("dbo.Capabilities");
            AddForeignKey("dbo.AccUserRoles", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
        }
    }
}
