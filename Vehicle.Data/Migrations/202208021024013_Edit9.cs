namespace Vehicle.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Confirmations", "UserWhoConfirmedId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Confirmations", "UserWhoConfirmedId");
            AddForeignKey("dbo.Confirmations", "UserWhoConfirmedId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Confirmations", "UserWhoConfirmed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Confirmations", "UserWhoConfirmed", c => c.String());
            DropForeignKey("dbo.Confirmations", "UserWhoConfirmedId", "dbo.AspNetUsers");
            DropIndex("dbo.Confirmations", new[] { "UserWhoConfirmedId" });
            DropColumn("dbo.Confirmations", "UserWhoConfirmedId");
        }
    }
}
