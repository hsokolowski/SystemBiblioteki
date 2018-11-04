namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class borrowing : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Borrowing_id_borrow", c => c.Int());
            CreateIndex("dbo.Books", "Borrowing_id_borrow");
            AddForeignKey("dbo.Books", "Borrowing_id_borrow", "dbo.Borrowings", "id_borrow");
            DropColumn("dbo.Borrowings", "id_book");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Borrowings", "id_book", c => c.Int(nullable: false));
            DropForeignKey("dbo.Books", "Borrowing_id_borrow", "dbo.Borrowings");
            DropIndex("dbo.Books", new[] { "Borrowing_id_borrow" });
            DropColumn("dbo.Books", "Borrowing_id_borrow");
        }
    }
}
