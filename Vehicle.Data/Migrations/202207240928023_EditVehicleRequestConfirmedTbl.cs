namespace Vehicle.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditVehicleRequestConfirmedTbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VehicleRequestConfirmeds", "SecretarytId", c => c.String(maxLength: 128));
            CreateIndex("dbo.VehicleRequestConfirmeds", "SecretarytId");
            AddForeignKey("dbo.VehicleRequestConfirmeds", "SecretarytId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleRequestConfirmeds", "SecretarytId", "dbo.AspNetUsers");
            DropIndex("dbo.VehicleRequestConfirmeds", new[] { "SecretarytId" });
            DropColumn("dbo.VehicleRequestConfirmeds", "SecretarytId");
        }
    }
}
