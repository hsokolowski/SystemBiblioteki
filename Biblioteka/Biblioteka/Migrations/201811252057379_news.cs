namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class news : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "AccountID", c => c.Int(nullable: false));
            CreateIndex("dbo.News", "AccountID");
            AddForeignKey("dbo.News", "AccountID", "dbo.Accounts", "AccountID", cascadeDelete: true);
            DropColumn("dbo.News", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.News", "UserID", c => c.Int(nullable: false));
            DropForeignKey("dbo.News", "AccountID", "dbo.Accounts");
            DropIndex("dbo.News", new[] { "AccountID" });
            DropColumn("dbo.News", "AccountID");
        }
    }
}
