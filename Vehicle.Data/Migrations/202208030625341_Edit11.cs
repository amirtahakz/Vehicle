namespace Vehicle.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConfirmationsUsersWhoConfirmeds",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        VehicleRequestId = c.Guid(nullable: false),
                        UserWhoConfirmedId = c.String(maxLength: 128),
                        DateCreated = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserWhoConfirmedId)
                .ForeignKey("dbo.VehicleRequests", t => t.VehicleRequestId, cascadeDelete: true)
                .Index(t => t.VehicleRequestId)
                .Index(t => t.UserWhoConfirmedId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ConfirmationsUsersWhoConfirmeds", "VehicleRequestId", "dbo.VehicleRequests");
            DropForeignKey("dbo.ConfirmationsUsersWhoConfirmeds", "UserWhoConfirmedId", "dbo.AspNetUsers");
            DropIndex("dbo.ConfirmationsUsersWhoConfirmeds", new[] { "UserWhoConfirmedId" });
            DropIndex("dbo.ConfirmationsUsersWhoConfirmeds", new[] { "VehicleRequestId" });
            DropTable("dbo.ConfirmationsUsersWhoConfirmeds");
        }
    }
}
