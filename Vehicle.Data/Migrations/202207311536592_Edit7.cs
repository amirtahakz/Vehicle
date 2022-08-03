namespace Vehicle.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VehicleRequests", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.VehicleRequests", new[] { "UserId" });
            AddColumn("dbo.Confirmations", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Confirmations", "UserId");
            AddForeignKey("dbo.Confirmations", "UserId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.VehicleRequests", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VehicleRequests", "UserId", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Confirmations", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Confirmations", new[] { "UserId" });
            DropColumn("dbo.Confirmations", "UserId");
            CreateIndex("dbo.VehicleRequests", "UserId");
            AddForeignKey("dbo.VehicleRequests", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
