namespace Vehicle.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Confirmations", "SecretaryIsConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Confirmations", "DriverIsConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Confirmations", "FinalIsConfirmed", c => c.Boolean(nullable: false));
            DropColumn("dbo.Confirmations", "IsConfirmed");
            DropColumn("dbo.VehicleRequests", "IsConfirmed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VehicleRequests", "IsConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Confirmations", "IsConfirmed", c => c.Boolean(nullable: false));
            DropColumn("dbo.Confirmations", "FinalIsConfirmed");
            DropColumn("dbo.Confirmations", "DriverIsConfirmed");
            DropColumn("dbo.Confirmations", "SecretaryIsConfirmed");
        }
    }
}
