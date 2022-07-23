namespace Vehicle.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVehicleTblVehicleRequestConfirmedTblVehicleRequestTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehicleRequestConfirmeds",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DriverId = c.String(maxLength: 128),
                        VehicleRequestId = c.Guid(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.DriverId)
                .ForeignKey("dbo.VehicleRequests", t => t.VehicleRequestId, cascadeDelete: true)
                .Index(t => t.DriverId)
                .Index(t => t.VehicleRequestId);
            
            CreateTable(
                "dbo.VehicleRequests",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        EmployeeId = c.String(maxLength: 128),
                        VehicleId = c.Guid(nullable: false),
                        Origin = c.String(),
                        Destination = c.String(),
                        Description = c.String(),
                        SecretaryConfirmed = c.Boolean(nullable: false),
                        DriverConfirmed = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.EmployeeId)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleRequestConfirmeds", "VehicleRequestId", "dbo.VehicleRequests");
            DropForeignKey("dbo.VehicleRequests", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.VehicleRequests", "EmployeeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.VehicleRequestConfirmeds", "DriverId", "dbo.AspNetUsers");
            DropIndex("dbo.VehicleRequests", new[] { "VehicleId" });
            DropIndex("dbo.VehicleRequests", new[] { "EmployeeId" });
            DropIndex("dbo.VehicleRequestConfirmeds", new[] { "VehicleRequestId" });
            DropIndex("dbo.VehicleRequestConfirmeds", new[] { "DriverId" });
            DropTable("dbo.Vehicles");
            DropTable("dbo.VehicleRequests");
            DropTable("dbo.VehicleRequestConfirmeds");
        }
    }
}
