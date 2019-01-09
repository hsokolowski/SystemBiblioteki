namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class autbook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "autors_Books_BookID", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "autors_Books_Title", c => c.String());
            AddColumn("dbo.Books", "autors_Books_ISBN", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "autors_Books_Pages", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "autors_Books_Year", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "autors_Books_Year");
            DropColumn("dbo.Books", "autors_Books_Pages");
            DropColumn("dbo.Books", "autors_Books_ISBN");
            DropColumn("dbo.Books", "autors_Books_Title");
            DropColumn("dbo.Books", "autors_Books_BookID");
        }
    }
}
