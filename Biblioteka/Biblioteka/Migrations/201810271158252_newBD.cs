namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newBD : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        id_account = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        surname = c.String(nullable: false),
                        pesel = c.String(nullable: false),
                        email = c.String(nullable: false),
                        activ = c.Boolean(nullable: false),
                        login = c.String(nullable: false),
                        password = c.String(nullable: false, maxLength: 100),
                        confirmedpassword = c.String(),
                    })
                .PrimaryKey(t => t.id_account);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        id_author = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        surname = c.String(nullable: false),
                        country = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id_author);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        id_book = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false),
                        authorID = c.Int(nullable: false),
                        year = c.Int(nullable: false),
                        id_category = c.Int(nullable: false),
                        ilosc_str = c.Int(nullable: false),
                        ISBN = c.Int(nullable: false),
                        for_who = c.String(),
                    })
                .PrimaryKey(t => t.id_book);
            
            CreateTable(
                "dbo.Borrowings",
                c => new
                    {
                        id_borrow = c.Int(nullable: false, identity: true),
                        id_reader = c.Int(nullable: false),
                        id_book = c.Int(nullable: false),
                        date_borrow = c.DateTime(nullable: false),
                        date_back = c.DateTime(nullable: false),
                        id_penalty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_borrow);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        id_category = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id_category);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        id_news = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false),
                        date = c.DateTime(nullable: false),
                        id_employer = c.Int(nullable: false),
                        content = c.String(),
                    })
                .PrimaryKey(t => t.id_news);
            
            CreateTable(
                "dbo.Penalties",
                c => new
                    {
                        id_penalty = c.Int(nullable: false, identity: true),
                        amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_penalty);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        id_position = c.Int(nullable: false, identity: true),
                        ISBN = c.Int(nullable: false),
                        condition = c.Int(nullable: false),
                        id_book = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_position);
            
            CreateTable(
                "dbo.Queues",
                c => new
                    {
                        id_queue = c.Int(nullable: false, identity: true),
                        ISBN = c.Int(nullable: false),
                        queue = c.Int(nullable: false),
                        id_reader = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_queue);
            
            DropTable("dbo.Czytelniks");
            DropTable("dbo.Kategorias");
            DropTable("dbo.Ksiazkas");
            DropTable("dbo.Pracowniks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Pracowniks",
                c => new
                    {
                        pracownikID = c.Int(nullable: false, identity: true),
                        imie_p = c.String(nullable: false),
                        nazwisko_p = c.String(nullable: false),
                        email_p = c.String(nullable: false),
                        login_p = c.String(nullable: false),
                        password_p = c.String(nullable: false, maxLength: 100),
                        confirmedpassword_p = c.String(),
                    })
                .PrimaryKey(t => t.pracownikID);
            
            CreateTable(
                "dbo.Ksiazkas",
                c => new
                    {
                        ksiazkaID = c.Int(nullable: false, identity: true),
                        tytul = c.String(nullable: false),
                        autor = c.String(nullable: false),
                        rok = c.Int(nullable: false),
                        TypeString = c.String(),
                        ilosc_str = c.Int(nullable: false),
                        data = c.DateTime(nullable: false),
                        dla_kogo = c.String(),
                    })
                .PrimaryKey(t => t.ksiazkaID);
            
            CreateTable(
                "dbo.Kategorias",
                c => new
                    {
                        katid = c.Int(nullable: false, identity: true),
                        kategoria = c.String(),
                    })
                .PrimaryKey(t => t.katid);
            
            CreateTable(
                "dbo.Czytelniks",
                c => new
                    {
                        czytelnikID = c.Int(nullable: false, identity: true),
                        imie_c = c.String(nullable: false),
                        nazwisko_c = c.String(nullable: false),
                        pesel_c = c.String(nullable: false),
                        email_c = c.String(nullable: false),
                        login_c = c.String(nullable: false),
                        password_c = c.String(nullable: false, maxLength: 100),
                        confirmedpassword_c = c.String(),
                    })
                .PrimaryKey(t => t.czytelnikID);
            
            DropTable("dbo.Queues");
            DropTable("dbo.Positions");
            DropTable("dbo.Penalties");
            DropTable("dbo.News");
            DropTable("dbo.Categories");
            DropTable("dbo.Borrowings");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
            DropTable("dbo.Accounts");
        }
    }
}
