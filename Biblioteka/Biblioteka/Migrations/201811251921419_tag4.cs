namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tag4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tags", "Book_BookID", "dbo.Books");
            DropIndex("dbo.Tags", new[] { "Book_BookID" });
            RenameColumn(table: "dbo.Tags", name: "Book_BookID", newName: "BookID");
            AlterColumn("dbo.Tags", "BookID", c => c.Int(nullable: false));
            CreateIndex("dbo.Tags", "BookID");
            AddForeignKey("dbo.Tags", "BookID", "dbo.Books", "BookID", cascadeDelete: true);
            DropColumn("dbo.Categories", "id_father");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "id_father", c => c.Int(nullable: false));
            DropForeignKey("dbo.Tags", "BookID", "dbo.Books");
            DropIndex("dbo.Tags", new[] { "BookID" });
            AlterColumn("dbo.Tags", "BookID", c => c.Int());
            RenameColumn(table: "dbo.Tags", name: "BookID", newName: "Book_BookID");
            CreateIndex("dbo.Tags", "Book_BookID");
            AddForeignKey("dbo.Tags", "Book_BookID", "dbo.Books", "BookID");
        }
    }
}
