namespace ERPProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AccUserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AccUser", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AccUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserName = c.String(maxLength: 50),
                        Password = c.String(maxLength: 50),
                        Email = c.String(),
                        IsOnline = c.Boolean(nullable: false),
                        PasswordSalt = c.String(),
                        IsApproved = c.Boolean(nullable: false),
                        EmployeeId = c.Int(),
                        UnitId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccUserRoles", "UserId", "dbo.AccUser");
            DropForeignKey("dbo.AccUserRoles", "RoleId", "dbo.Roles");
            DropIndex("dbo.AccUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AccUserRoles", new[] { "UserId" });
            DropTable("dbo.AccUser");
            DropTable("dbo.AccUserRoles");
            DropTable("dbo.Roles");
        }
    }
}
