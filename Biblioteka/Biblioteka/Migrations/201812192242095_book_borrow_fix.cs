namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class book_borrow_fix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "Borrowing_BorrowID", "dbo.Borrowings");
            DropIndex("dbo.Books", new[] { "Borrowing_BorrowID" });
            AddColumn("dbo.Borrowings", "BookID", c => c.Int(nullable: false));
            CreateIndex("dbo.Borrowings", "BookID");
            AddForeignKey("dbo.Borrowings", "BookID", "dbo.Books", "BookID", cascadeDelete: true);
            DropColumn("dbo.Books", "Borrowing_BorrowID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Borrowing_BorrowID", c => c.Int());
            DropForeignKey("dbo.Borrowings", "BookID", "dbo.Books");
            DropIndex("dbo.Borrowings", new[] { "BookID" });
            DropColumn("dbo.Borrowings", "BookID");
            CreateIndex("dbo.Books", "Borrowing_BorrowID");
            AddForeignKey("dbo.Books", "Borrowing_BorrowID", "dbo.Borrowings", "BorrowID");
        }
    }
}
