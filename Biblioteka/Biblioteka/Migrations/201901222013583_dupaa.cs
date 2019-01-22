namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dupaa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tags", "Book_BookID", "dbo.Books");
            DropForeignKey("dbo.Books", "Tag_TagID", "dbo.Tags");
            DropForeignKey("dbo.Tags", "Book_BookID1", "dbo.Books");
            DropIndex("dbo.Books", new[] { "Tag_TagID" });
            DropIndex("dbo.Tags", new[] { "Book_BookID" });
            DropIndex("dbo.Tags", new[] { "Book_BookID1" });
            DropColumn("dbo.Books", "Tag_TagID");
            DropColumn("dbo.Tags", "BookID");
            DropColumn("dbo.Tags", "Book_BookID");
           
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tags", "Book_BookID1", c => c.Int());
            AddColumn("dbo.Tags", "Book_BookID", c => c.Int());
            AddColumn("dbo.Tags", "BookID", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "Tag_TagID", c => c.Int());
            CreateIndex("dbo.Tags", "Book_BookID1");
            CreateIndex("dbo.Tags", "Book_BookID");
            CreateIndex("dbo.Books", "Tag_TagID");
            AddForeignKey("dbo.Tags", "Book_BookID1", "dbo.Books", "BookID");
            AddForeignKey("dbo.Books", "Tag_TagID", "dbo.Tags", "TagID");
            AddForeignKey("dbo.Tags", "Book_BookID", "dbo.Books", "BookID");
        }
    }
}
