namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class borrow : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Borrowings", "Returned", c => c.Boolean(nullable: false));
            DropColumn("dbo.Books", "autors_Books_BookID");
            DropColumn("dbo.Books", "autors_Books_Title");
            DropColumn("dbo.Books", "autors_Books_ISBN");
            DropColumn("dbo.Books", "autors_Books_Pages");
            DropColumn("dbo.Books", "autors_Books_Year");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "autors_Books_Year", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "autors_Books_Pages", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "autors_Books_ISBN", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "autors_Books_Title", c => c.String());
            AddColumn("dbo.Books", "autors_Books_BookID", c => c.Int(nullable: false));
            DropColumn("dbo.Borrowings", "Returned");
        }
    }
}
