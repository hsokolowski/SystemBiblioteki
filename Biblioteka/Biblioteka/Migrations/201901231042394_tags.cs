namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tags : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tags", "BookID", "dbo.Books");
            DropIndex("dbo.Tags", new[] { "BookID" });
            CreateTable(
                "dbo.TagBooks",
                c => new
                    {
                        TagBookID = c.Int(nullable: false, identity: true),
                        TagID = c.Int(nullable: false),
                        BookID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TagBookID)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagID, cascadeDelete: true)
                .Index(t => t.TagID)
                .Index(t => t.BookID);
            
            DropColumn("dbo.Tags", "BookID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tags", "BookID", c => c.Int(nullable: false));
            DropForeignKey("dbo.TagBooks", "TagID", "dbo.Tags");
            DropForeignKey("dbo.TagBooks", "BookID", "dbo.Books");
            DropIndex("dbo.TagBooks", new[] { "BookID" });
            DropIndex("dbo.TagBooks", new[] { "TagID" });
            DropTable("dbo.TagBooks");
            CreateIndex("dbo.Tags", "BookID");
            AddForeignKey("dbo.Tags", "BookID", "dbo.Books", "BookID", cascadeDelete: true);
        }
    }
}
