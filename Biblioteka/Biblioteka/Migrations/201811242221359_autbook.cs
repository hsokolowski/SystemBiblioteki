namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class autbook : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Authors");
            DropPrimaryKey("dbo.Books");
            DropColumn("dbo.Authors", "id_author");
            DropColumn("dbo.Books", "id_book");
            DropColumn("dbo.Books", "id_author");
            DropColumn("dbo.Books", "id_category");
            DropColumn("dbo.Books", "ilosc_str");

            CreateTable(
                "dbo.AutBooks",
                c => new
                    {
                        AutBookID = c.Int(nullable: false, identity: true),
                        AuthorID = c.Int(nullable: false),
                        BookID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AutBookID)
                .ForeignKey("dbo.Authors", t => t.AuthorID, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .Index(t => t.AuthorID)
                .Index(t => t.BookID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        id_tag = c.String(nullable: false, maxLength: 128),
                        tag = c.String(nullable: false),
                        id_book = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_tag);
            
            AddColumn("dbo.Authors", "AuthorID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Books", "BookID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Books", "CategoryID", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "Pages", c => c.Int(nullable: false));
            AddColumn("dbo.Categories", "id_father", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Authors", "AuthorID");
            AddPrimaryKey("dbo.Books", "BookID");
           
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "ilosc_str", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "id_category", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "id_author", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "id_book", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Authors", "id_author", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.AutBooks", "BookID", "dbo.Books");
            DropForeignKey("dbo.AutBooks", "AuthorID", "dbo.Authors");
            DropIndex("dbo.AutBooks", new[] { "BookID" });
            DropIndex("dbo.AutBooks", new[] { "AuthorID" });
            DropPrimaryKey("dbo.Books");
            DropPrimaryKey("dbo.Authors");
            DropColumn("dbo.Categories", "id_father");
            DropColumn("dbo.Books", "Pages");
            DropColumn("dbo.Books", "CategoryID");
            DropColumn("dbo.Books", "BookID");
            DropColumn("dbo.Authors", "AuthorID");
            DropTable("dbo.Tags");
            DropTable("dbo.AutBooks");
            AddPrimaryKey("dbo.Books", "id_book");
            AddPrimaryKey("dbo.Authors", "id_author");
        }
    }
}
