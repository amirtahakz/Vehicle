namespace Vehicle.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUserRefreshTokenTbl : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.UserRefreshTokens");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserRefreshTokens",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.String(),
                        RefreshToken = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
