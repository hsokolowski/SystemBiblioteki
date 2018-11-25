namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tag_book : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "Borrowing_id_borrow", "dbo.Borrowings");
            RenameColumn(table: "dbo.Books", name: "Borrowing_id_borrow", newName: "Borrowing_BorrowID");
            RenameIndex(table: "dbo.Books", name: "IX_Borrowing_id_borrow", newName: "IX_Borrowing_BorrowID");
            DropPrimaryKey("dbo.Accounts");
            DropPrimaryKey("dbo.Borrowings");
            DropPrimaryKey("dbo.Categories");
            DropPrimaryKey("dbo.News");
            DropPrimaryKey("dbo.Penalties");
            DropPrimaryKey("dbo.Queues");
            DropPrimaryKey("dbo.Tags");
            DropColumn("dbo.Accounts", "id_account");
            DropColumn("dbo.Borrowings", "id_borrow");
            DropColumn("dbo.Categories", "id_category");
            DropColumn("dbo.News", "id_news");
            DropColumn("dbo.Penalties", "id_penalty");
            DropColumn("dbo.Queues", "id_queue");
            DropColumn("dbo.Tags", "id_tag");


            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Stream = c.String(),
                        BookID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileID);
            
            CreateTable(
                "dbo.Repositories",
                c => new
                    {
                        RepositoryID = c.Int(nullable: false, identity: true),
                        ISBN = c.Int(nullable: false),
                        BookID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RepositoryID)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .Index(t => t.BookID);
            
            AddColumn("dbo.Accounts", "AccountID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Accounts", "Active", c => c.Boolean(nullable: false));
            AddColumn("dbo.Books", "TagID", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "Tag_TagID", c => c.String(maxLength: 128));
            AddColumn("dbo.Borrowings", "BorrowID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Borrowings", "ReaderID", c => c.Int(nullable: false));
            AddColumn("dbo.Borrowings", "Borrow_date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Borrowings", "Return_date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Borrowings", "PenaltyID", c => c.Int(nullable: false));
            AddColumn("dbo.Borrowings", "QueueID", c => c.Int(nullable: false));
            AddColumn("dbo.Categories", "CategoryID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.News", "NewsID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.News", "UserID", c => c.Int(nullable: false));
            AddColumn("dbo.Penalties", "PenaltyID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Penalties", "Value", c => c.Int(nullable: false));
            AddColumn("dbo.Penalties", "Days", c => c.Int(nullable: false));
            AddColumn("dbo.Queues", "QueueID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Queues", "BookID", c => c.Int(nullable: false));
            AddColumn("dbo.Queues", "Order", c => c.Int(nullable: false));
            AddColumn("dbo.Queues", "AcountID", c => c.Int(nullable: false));
            AddColumn("dbo.Tags", "TagID", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Tags", "Name", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Accounts", "AccountID");
            AddPrimaryKey("dbo.Borrowings", "BorrowID");
            AddPrimaryKey("dbo.Categories", "CategoryID");
            AddPrimaryKey("dbo.News", "NewsID");
            AddPrimaryKey("dbo.Penalties", "PenaltyID");
            AddPrimaryKey("dbo.Queues", "QueueID");
            AddPrimaryKey("dbo.Tags", "TagID");
            CreateIndex("dbo.Books", "Tag_TagID");
            AddForeignKey("dbo.Books", "Tag_TagID", "dbo.Tags", "TagID");
            AddForeignKey("dbo.Books", "Borrowing_BorrowID", "dbo.Borrowings", "BorrowID");
            DropColumn("dbo.Accounts", "activ");
            DropColumn("dbo.Borrowings", "id_reader");
            DropColumn("dbo.Borrowings", "date_borrow");
            DropColumn("dbo.Borrowings", "date_back");
            DropColumn("dbo.Borrowings", "id_penalty");
            DropColumn("dbo.Borrowings", "id_queue");
            DropColumn("dbo.News", "id_employer");
            DropColumn("dbo.Penalties", "amount");
            DropColumn("dbo.Queues", "id_book");
            DropColumn("dbo.Queues", "queue");
            DropColumn("dbo.Queues", "id_reader");
            DropColumn("dbo.Tags", "tag");
            DropColumn("dbo.Tags", "id_book");
            DropTable("dbo.FileBooks");
            DropTable("dbo.Positions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        id_position = c.Int(nullable: false, identity: true),
                        ISBN = c.Int(nullable: false),
                        id_book = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_position);
            
            CreateTable(
                "dbo.FileBooks",
                c => new
                    {
                        id_file = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        stream = c.String(),
                        id_book = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_file);
            
            AddColumn("dbo.Tags", "id_book", c => c.Int(nullable: false));
            AddColumn("dbo.Tags", "tag", c => c.String(nullable: false));
            AddColumn("dbo.Tags", "id_tag", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Queues", "id_reader", c => c.Int(nullable: false));
            AddColumn("dbo.Queues", "queue", c => c.Int(nullable: false));
            AddColumn("dbo.Queues", "id_book", c => c.Int(nullable: false));
            AddColumn("dbo.Queues", "id_queue", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Penalties", "amount", c => c.Int(nullable: false));
            AddColumn("dbo.Penalties", "id_penalty", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.News", "id_employer", c => c.Int(nullable: false));
            AddColumn("dbo.News", "id_news", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Categories", "id_category", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Borrowings", "id_queue", c => c.Int(nullable: false));
            AddColumn("dbo.Borrowings", "id_penalty", c => c.Int(nullable: false));
            AddColumn("dbo.Borrowings", "date_back", c => c.DateTime(nullable: false));
            AddColumn("dbo.Borrowings", "date_borrow", c => c.DateTime(nullable: false));
            AddColumn("dbo.Borrowings", "id_reader", c => c.Int(nullable: false));
            AddColumn("dbo.Borrowings", "id_borrow", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Accounts", "activ", c => c.Boolean(nullable: false));
            AddColumn("dbo.Accounts", "id_account", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Books", "Borrowing_BorrowID", "dbo.Borrowings");
            DropForeignKey("dbo.Repositories", "BookID", "dbo.Books");
            DropForeignKey("dbo.Books", "Tag_TagID", "dbo.Tags");
            DropIndex("dbo.Repositories", new[] { "BookID" });
            DropIndex("dbo.Books", new[] { "Tag_TagID" });
            DropPrimaryKey("dbo.Tags");
            DropPrimaryKey("dbo.Queues");
            DropPrimaryKey("dbo.Penalties");
            DropPrimaryKey("dbo.News");
            DropPrimaryKey("dbo.Categories");
            DropPrimaryKey("dbo.Borrowings");
            DropPrimaryKey("dbo.Accounts");
            DropColumn("dbo.Tags", "Name");
            DropColumn("dbo.Tags", "TagID");
            DropColumn("dbo.Queues", "AcountID");
            DropColumn("dbo.Queues", "Order");
            DropColumn("dbo.Queues", "BookID");
            DropColumn("dbo.Queues", "QueueID");
            DropColumn("dbo.Penalties", "Days");
            DropColumn("dbo.Penalties", "Value");
            DropColumn("dbo.Penalties", "PenaltyID");
            DropColumn("dbo.News", "UserID");
            DropColumn("dbo.News", "NewsID");
            DropColumn("dbo.Categories", "CategoryID");
            DropColumn("dbo.Borrowings", "QueueID");
            DropColumn("dbo.Borrowings", "PenaltyID");
            DropColumn("dbo.Borrowings", "Return_date");
            DropColumn("dbo.Borrowings", "Borrow_date");
            DropColumn("dbo.Borrowings", "ReaderID");
            DropColumn("dbo.Borrowings", "BorrowID");
            DropColumn("dbo.Books", "Tag_TagID");
            DropColumn("dbo.Books", "TagID");
            DropColumn("dbo.Accounts", "Active");
            DropColumn("dbo.Accounts", "AccountID");
            DropTable("dbo.Repositories");
            DropTable("dbo.Files");
            AddPrimaryKey("dbo.Tags", "id_tag");
            AddPrimaryKey("dbo.Queues", "id_queue");
            AddPrimaryKey("dbo.Penalties", "id_penalty");
            AddPrimaryKey("dbo.News", "id_news");
            AddPrimaryKey("dbo.Categories", "id_category");
            AddPrimaryKey("dbo.Borrowings", "id_borrow");
            AddPrimaryKey("dbo.Accounts", "id_account");
            RenameIndex(table: "dbo.Books", name: "IX_Borrowing_BorrowID", newName: "IX_Borrowing_id_borrow");
            RenameColumn(table: "dbo.Books", name: "Borrowing_BorrowID", newName: "Borrowing_id_borrow");
            AddForeignKey("dbo.Books", "Borrowing_id_borrow", "dbo.Borrowings", "id_borrow");
        }
    }
}
