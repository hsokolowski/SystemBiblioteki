namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class queue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Queues", "Account_AccountID", c => c.Int());
            CreateIndex("dbo.Queues", "BookID");
            CreateIndex("dbo.Queues", "Account_AccountID");
            AddForeignKey("dbo.Queues", "Account_AccountID", "dbo.Accounts", "AccountID");
            AddForeignKey("dbo.Queues", "BookID", "dbo.Books", "BookID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Queues", "BookID", "dbo.Books");
            DropForeignKey("dbo.Queues", "Account_AccountID", "dbo.Accounts");
            DropIndex("dbo.Queues", new[] { "Account_AccountID" });
            DropIndex("dbo.Queues", new[] { "BookID" });
            DropColumn("dbo.Queues", "Account_AccountID");
        }
    }
}
