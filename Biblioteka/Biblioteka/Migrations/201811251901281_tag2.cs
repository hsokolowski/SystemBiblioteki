namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tag2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "Tag_TagID", "dbo.Tags");
            DropForeignKey("dbo.Repositories", "BookID", "dbo.Books");
            DropIndex("dbo.Books", new[] { "Tag_TagID" });
            DropIndex("dbo.Repositories", new[] { "BookID" });
            AddColumn("dbo.Tags", "Book_BookID", c => c.Int());
            CreateIndex("dbo.Tags", "Book_BookID");
            AddForeignKey("dbo.Tags", "Book_BookID", "dbo.Books", "BookID");
            DropColumn("dbo.Books", "TagID");
            DropColumn("dbo.Books", "Tag_TagID");
            DropColumn("dbo.Repositories", "BookID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Repositories", "BookID", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "Tag_TagID", c => c.String(maxLength: 128));
            AddColumn("dbo.Books", "TagID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Tags", "Book_BookID", "dbo.Books");
            DropIndex("dbo.Tags", new[] { "Book_BookID" });
            DropColumn("dbo.Tags", "Book_BookID");
            CreateIndex("dbo.Repositories", "BookID");
            CreateIndex("dbo.Books", "Tag_TagID");
            AddForeignKey("dbo.Repositories", "BookID", "dbo.Books", "BookID", cascadeDelete: true);
            AddForeignKey("dbo.Books", "Tag_TagID", "dbo.Tags", "TagID");
        }
    }
}
