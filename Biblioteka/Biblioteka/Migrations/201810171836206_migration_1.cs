namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration_1 : DbMigration
    {
        public override void Up()
        {
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
            
            CreateTable(
                "dbo.Kategorias",
                c => new
                    {
                        katid = c.Int(nullable: false, identity: true),
                        kategoria = c.String(),
                    })
                .PrimaryKey(t => t.katid);
            
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pracowniks");
            DropTable("dbo.Ksiazkas");
            DropTable("dbo.Kategorias");
            DropTable("dbo.Czytelniks");
        }
    }
}
