namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class filev1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FileBooks",
                c => new
                    {
                        id_file = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        stream = c.String(),
                        id_book = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_file);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FileBooks");
        }
    }
}
