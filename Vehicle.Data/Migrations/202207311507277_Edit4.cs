namespace Vehicle.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DriverConfirmations", "IsConfirmed");
            DropColumn("dbo.SecretaryConfirmations", "IsConfirmed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SecretaryConfirmations", "IsConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.DriverConfirmations", "IsConfirmed", c => c.Boolean(nullable: false));
        }
    }
}
