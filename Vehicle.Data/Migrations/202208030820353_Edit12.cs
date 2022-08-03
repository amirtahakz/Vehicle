namespace Vehicle.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Confirmations", "UserWhoConfirmedId", "dbo.AspNetUsers");
            DropIndex("dbo.Confirmations", new[] { "UserWhoConfirmedId" });
            DropColumn("dbo.Confirmations", "UserWhoConfirmedId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Confirmations", "UserWhoConfirmedId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Confirmations", "UserWhoConfirmedId");
            AddForeignKey("dbo.Confirmations", "UserWhoConfirmedId", "dbo.AspNetUsers", "Id");
        }
    }
}
