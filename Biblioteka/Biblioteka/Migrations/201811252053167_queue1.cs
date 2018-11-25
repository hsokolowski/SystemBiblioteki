namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class queue1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Queues", "Account_AccountID", "dbo.Accounts");
            DropIndex("dbo.Queues", new[] { "Account_AccountID" });
            RenameColumn(table: "dbo.Queues", name: "Account_AccountID", newName: "AccountID");
            AlterColumn("dbo.Queues", "AccountID", c => c.Int(nullable: false));
            CreateIndex("dbo.Queues", "AccountID");
            AddForeignKey("dbo.Queues", "AccountID", "dbo.Accounts", "AccountID", cascadeDelete: true);
            DropColumn("dbo.Queues", "AcountID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Queues", "AcountID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Queues", "AccountID", "dbo.Accounts");
            DropIndex("dbo.Queues", new[] { "AccountID" });
            AlterColumn("dbo.Queues", "AccountID", c => c.Int());
            RenameColumn(table: "dbo.Queues", name: "AccountID", newName: "Account_AccountID");
            CreateIndex("dbo.Queues", "Account_AccountID");
            AddForeignKey("dbo.Queues", "Account_AccountID", "dbo.Accounts", "AccountID");
        }
    }
}
