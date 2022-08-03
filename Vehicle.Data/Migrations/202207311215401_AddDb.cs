namespace Vehicle.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DriverConfirmations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserWhoConfirmedId = c.String(maxLength: 128),
                        VehicleRequestId = c.Guid(nullable: false),
                        IsConfirmed = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserWhoConfirmedId)
                .ForeignKey("dbo.VehicleRequests", t => t.VehicleRequestId, cascadeDelete: true)
                .Index(t => t.UserWhoConfirmedId)
                .Index(t => t.VehicleRequestId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ManagerConfirmed = c.Boolean(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.VehicleRequests",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.String(maxLength: 128),
                        VehicleId = c.Guid(nullable: false),
                        Origin = c.String(),
                        Destination = c.String(),
                        Description = c.String(),
                        IsConfirmed = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CarTag = c.String(),
                        Color = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.SecretaryConfirmations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserWhoConfirmedId = c.String(maxLength: 128),
                        VehicleRequestId = c.Guid(nullable: false),
                        IsConfirmed = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserWhoConfirmedId)
                .ForeignKey("dbo.VehicleRequests", t => t.VehicleRequestId, cascadeDelete: true)
                .Index(t => t.UserWhoConfirmedId)
                .Index(t => t.VehicleRequestId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SecretaryConfirmations", "VehicleRequestId", "dbo.VehicleRequests");
            DropForeignKey("dbo.SecretaryConfirmations", "UserWhoConfirmedId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.DriverConfirmations", "VehicleRequestId", "dbo.VehicleRequests");
            DropForeignKey("dbo.VehicleRequests", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.VehicleRequests", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.DriverConfirmations", "UserWhoConfirmedId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.SecretaryConfirmations", new[] { "VehicleRequestId" });
            DropIndex("dbo.SecretaryConfirmations", new[] { "UserWhoConfirmedId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.VehicleRequests", new[] { "VehicleId" });
            DropIndex("dbo.VehicleRequests", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.DriverConfirmations", new[] { "VehicleRequestId" });
            DropIndex("dbo.DriverConfirmations", new[] { "UserWhoConfirmedId" });
            DropTable("dbo.SecretaryConfirmations");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Vehicles");
            DropTable("dbo.VehicleRequests");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.DriverConfirmations");
        }
    }
}
