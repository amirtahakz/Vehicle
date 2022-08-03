namespace Vehicle.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Confirmations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        VehicleRequestId = c.Guid(nullable: false),
                        IsConfirmed = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VehicleRequests", t => t.VehicleRequestId, cascadeDelete: true)
                .Index(t => t.VehicleRequestId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Confirmations", "VehicleRequestId", "dbo.VehicleRequests");
            DropIndex("dbo.Confirmations", new[] { "VehicleRequestId" });
            DropTable("dbo.Confirmations");
        }
    }
}
