namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class history_borrow : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Pesel = c.String(nullable: false, maxLength: 11),
                        Email = c.String(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 100),
                        Confirmedpassword = c.String(),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccountID);
            
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
                "dbo.News",
                c => new
                    {
                        NewsID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        AccountID = c.Int(nullable: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.NewsID)
                .ForeignKey("dbo.Accounts", t => t.AccountID, cascadeDelete: true)
                .Index(t => t.AccountID);
            
            CreateTable(
                "dbo.Queues",
                c => new
                    {
                        QueueID = c.Int(nullable: false, identity: true),
                        BookID = c.Int(nullable: false),
                        Order = c.Int(nullable: false),
                        AccountID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QueueID)
                .ForeignKey("dbo.Accounts", t => t.AccountID, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .Index(t => t.BookID)
                .Index(t => t.AccountID);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Year = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        Pages = c.Int(nullable: false),
                        ISBN = c.Int(nullable: false),
                        for_who_string = c.String(),
                    })
                .PrimaryKey(t => t.BookID);
            
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
                "dbo.Authors",
                c => new
                    {
                        AuthorID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AuthorID);
            
            CreateTable(
                "dbo.Borrowings",
                c => new
                    {
                        BorrowID = c.Int(nullable: false, identity: true),
                        ReaderID = c.Int(nullable: false),
                        Borrow_date = c.DateTime(nullable: false),
                        Return_date = c.DateTime(nullable: false),
                        PenaltyID = c.Int(nullable: false),
                        QueueID = c.Int(nullable: false),
                        BookID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BorrowID)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.Penalties", t => t.PenaltyID, cascadeDelete: true)
                .Index(t => t.PenaltyID)
                .Index(t => t.BookID);
            
            CreateTable(
                "dbo.Penalties",
                c => new
                    {
                        PenaltyID = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        Days = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PenaltyID);
            
            CreateTable(
                "dbo.Repositories",
                c => new
                    {
                        RepositoryID = c.Int(nullable: false),
                        ISBN = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RepositoryID)
                .ForeignKey("dbo.Books", t => t.RepositoryID)
                .Index(t => t.RepositoryID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        BookID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TagID)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .Index(t => t.BookID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        SubCategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubCategoryID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Path = c.String(),
                        BookID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileID)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .Index(t => t.BookID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Files", "BookID", "dbo.Books");
            DropForeignKey("dbo.SubCategories", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Tags", "BookID", "dbo.Books");
            DropForeignKey("dbo.Repositories", "RepositoryID", "dbo.Books");
            DropForeignKey("dbo.Queues", "BookID", "dbo.Books");
            DropForeignKey("dbo.Borrowings", "PenaltyID", "dbo.Penalties");
            DropForeignKey("dbo.Borrowings", "BookID", "dbo.Books");
            DropForeignKey("dbo.AutBooks", "BookID", "dbo.Books");
            DropForeignKey("dbo.AutBooks", "AuthorID", "dbo.Authors");
            DropForeignKey("dbo.Queues", "AccountID", "dbo.Accounts");
            DropForeignKey("dbo.News", "AccountID", "dbo.Accounts");
            DropForeignKey("dbo.Histories", "AccountID", "dbo.Accounts");
            DropIndex("dbo.Files", new[] { "BookID" });
            DropIndex("dbo.SubCategories", new[] { "CategoryID" });
            DropIndex("dbo.Tags", new[] { "BookID" });
            DropIndex("dbo.Repositories", new[] { "RepositoryID" });
            DropIndex("dbo.Borrowings", new[] { "BookID" });
            DropIndex("dbo.Borrowings", new[] { "PenaltyID" });
            DropIndex("dbo.AutBooks", new[] { "BookID" });
            DropIndex("dbo.AutBooks", new[] { "AuthorID" });
            DropIndex("dbo.Queues", new[] { "AccountID" });
            DropIndex("dbo.Queues", new[] { "BookID" });
            DropIndex("dbo.News", new[] { "AccountID" });
            DropIndex("dbo.Histories", new[] { "AccountID" });
            DropTable("dbo.Files");
            DropTable("dbo.SubCategories");
            DropTable("dbo.Categories");
            DropTable("dbo.Tags");
            DropTable("dbo.Repositories");
            DropTable("dbo.Penalties");
            DropTable("dbo.Borrowings");
            DropTable("dbo.Authors");
            DropTable("dbo.AutBooks");
            DropTable("dbo.Books");
            DropTable("dbo.Queues");
            DropTable("dbo.News");
            DropTable("dbo.Histories");
            DropTable("dbo.Accounts");
        }
    }
}
