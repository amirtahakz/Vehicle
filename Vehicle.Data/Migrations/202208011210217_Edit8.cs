namespace Vehicle.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DriverConfirmations", "UserWhoConfirmedId", "dbo.AspNetUsers");
            DropForeignKey("dbo.DriverConfirmations", "VehicleRequestId", "dbo.VehicleRequests");
            DropForeignKey("dbo.SecretaryConfirmations", "UserWhoConfirmedId", "dbo.AspNetUsers");
            DropForeignKey("dbo.SecretaryConfirmations", "VehicleRequestId", "dbo.VehicleRequests");
            DropIndex("dbo.DriverConfirmations", new[] { "UserWhoConfirmedId" });
            DropIndex("dbo.DriverConfirmations", new[] { "VehicleRequestId" });
            DropIndex("dbo.SecretaryConfirmations", new[] { "UserWhoConfirmedId" });
            DropIndex("dbo.SecretaryConfirmations", new[] { "VehicleRequestId" });
            AddColumn("dbo.Confirmations", "UserWhoConfirmed", c => c.String());
            AddColumn("dbo.VehicleRequests", "IsConfirmed", c => c.Boolean(nullable: false));
            DropColumn("dbo.Confirmations", "FirstStepIsConfirmed");
            DropTable("dbo.DriverConfirmations");
            DropTable("dbo.SecretaryConfirmations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SecretaryConfirmations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserWhoConfirmedId = c.String(maxLength: 128),
                        VehicleRequestId = c.Guid(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DriverConfirmations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserWhoConfirmedId = c.String(maxLength: 128),
                        VehicleRequestId = c.Guid(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Confirmations", "FirstStepIsConfirmed", c => c.Boolean(nullable: false));
            DropColumn("dbo.VehicleRequests", "IsConfirmed");
            DropColumn("dbo.Confirmations", "UserWhoConfirmed");
            CreateIndex("dbo.SecretaryConfirmations", "VehicleRequestId");
            CreateIndex("dbo.SecretaryConfirmations", "UserWhoConfirmedId");
            CreateIndex("dbo.DriverConfirmations", "VehicleRequestId");
            CreateIndex("dbo.DriverConfirmations", "UserWhoConfirmedId");
            AddForeignKey("dbo.SecretaryConfirmations", "VehicleRequestId", "dbo.VehicleRequests", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SecretaryConfirmations", "UserWhoConfirmedId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.DriverConfirmations", "VehicleRequestId", "dbo.VehicleRequests", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DriverConfirmations", "UserWhoConfirmedId", "dbo.AspNetUsers", "Id");
        }
    }
}
