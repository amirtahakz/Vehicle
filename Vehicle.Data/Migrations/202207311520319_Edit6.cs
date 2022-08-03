namespace Vehicle.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Confirmations", "FirstStepIsConfirmed", c => c.Boolean(nullable: false));
            DropColumn("dbo.VehicleRequests", "IsConfirmed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VehicleRequests", "IsConfirmed", c => c.Boolean(nullable: false));
            DropColumn("dbo.Confirmations", "FirstStepIsConfirmed");
        }
    }
}
