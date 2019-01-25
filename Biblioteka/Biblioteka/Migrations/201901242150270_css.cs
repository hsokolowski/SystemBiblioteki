namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class css : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tags", "BookID", "dbo.Books");
            DropIndex("dbo.Tags", new[] { "BookID" });
            CreateTable(
                "dbo.Histories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Search = c.String(),
                        SearchDate = c.DateTime(nullable: false),
                        AccountID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountID, cascadeDelete: true)
                .Index(t => t.AccountID);
            
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
            
            CreateTable(
                "dbo.Longlives",
                c => new
                    {
                        LonglifeID = c.Int(nullable: false, identity: true),
                        longlife = c.Int(nullable: false),
                        limit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LonglifeID);
            
            AddColumn("dbo.Authors", "FullName", c => c.String(nullable: false));
            AddColumn("dbo.Borrowings", "Returned", c => c.Boolean(nullable: false));
            AddColumn("dbo.Categories", "SubCategs", c => c.String(nullable: false));
            DropColumn("dbo.Tags", "BookID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tags", "BookID", c => c.Int(nullable: false));
            DropForeignKey("dbo.TagBooks", "TagID", "dbo.Tags");
            DropForeignKey("dbo.TagBooks", "BookID", "dbo.Books");
            DropForeignKey("dbo.Histories", "AccountID", "dbo.Accounts");
            DropIndex("dbo.TagBooks", new[] { "BookID" });
            DropIndex("dbo.TagBooks", new[] { "TagID" });
            DropIndex("dbo.Histories", new[] { "AccountID" });
            DropColumn("dbo.Categories", "SubCategs");
            DropColumn("dbo.Borrowings", "Returned");
            DropColumn("dbo.Authors", "FullName");
            DropTable("dbo.Longlives");
            DropTable("dbo.TagBooks");
            DropTable("dbo.Histories");
            CreateIndex("dbo.Tags", "BookID");
            AddForeignKey("dbo.Tags", "BookID", "dbo.Books", "BookID", cascadeDelete: true);
        }
    }
}
