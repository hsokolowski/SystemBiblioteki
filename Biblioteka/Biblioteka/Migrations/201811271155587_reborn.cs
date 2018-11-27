namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reborn : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Repositories");
            AddColumn("dbo.Files", "Path", c => c.String());
            AddColumn("dbo.News", "AccountID", c => c.Int(nullable: false));
            AddColumn("dbo.Repositories", "Amount", c => c.Int(nullable: false));
            AddColumn("dbo.Queues", "AccountID", c => c.Int(nullable: false));
            AlterColumn("dbo.Repositories", "RepositoryID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Repositories", "RepositoryID");
            CreateIndex("dbo.News", "AccountID");
            CreateIndex("dbo.Queues", "BookID");
            CreateIndex("dbo.Queues", "AccountID");
            CreateIndex("dbo.Repositories", "RepositoryID");
            CreateIndex("dbo.Borrowings", "PenaltyID");
            CreateIndex("dbo.Files", "BookID");
            AddForeignKey("dbo.News", "AccountID", "dbo.Accounts", "AccountID", cascadeDelete: true);
            AddForeignKey("dbo.Queues", "AccountID", "dbo.Accounts", "AccountID", cascadeDelete: true);
            AddForeignKey("dbo.Queues", "BookID", "dbo.Books", "BookID", cascadeDelete: true);
            AddForeignKey("dbo.Repositories", "RepositoryID", "dbo.Books", "BookID");
            AddForeignKey("dbo.Borrowings", "PenaltyID", "dbo.Penalties", "PenaltyID", cascadeDelete: true);
            AddForeignKey("dbo.Files", "BookID", "dbo.Books", "BookID", cascadeDelete: true);
            DropColumn("dbo.Files", "Stream");
            DropColumn("dbo.News", "UserID");
            DropColumn("dbo.Queues", "AcountID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Queues", "AcountID", c => c.Int(nullable: false));
            AddColumn("dbo.News", "UserID", c => c.Int(nullable: false));
            AddColumn("dbo.Files", "Stream", c => c.String());
            DropForeignKey("dbo.Files", "BookID", "dbo.Books");
            DropForeignKey("dbo.Borrowings", "PenaltyID", "dbo.Penalties");
            DropForeignKey("dbo.Repositories", "RepositoryID", "dbo.Books");
            DropForeignKey("dbo.Queues", "BookID", "dbo.Books");
            DropForeignKey("dbo.Queues", "AccountID", "dbo.Accounts");
            DropForeignKey("dbo.News", "AccountID", "dbo.Accounts");
            DropIndex("dbo.Files", new[] { "BookID" });
            DropIndex("dbo.Borrowings", new[] { "PenaltyID" });
            DropIndex("dbo.Repositories", new[] { "RepositoryID" });
            DropIndex("dbo.Queues", new[] { "AccountID" });
            DropIndex("dbo.Queues", new[] { "BookID" });
            DropIndex("dbo.News", new[] { "AccountID" });
            DropPrimaryKey("dbo.Repositories");
            AlterColumn("dbo.Repositories", "RepositoryID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Queues", "AccountID");
            DropColumn("dbo.Repositories", "Amount");
            DropColumn("dbo.News", "AccountID");
            DropColumn("dbo.Files", "Path");
            AddPrimaryKey("dbo.Repositories", "RepositoryID");
        }
    }
}
