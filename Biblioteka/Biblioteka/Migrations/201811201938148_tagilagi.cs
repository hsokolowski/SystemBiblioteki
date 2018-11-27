namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tagilagi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AutBooks",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        id_author = c.Int(nullable: false),
                        id_book = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        id_tag = c.String(nullable: false, maxLength: 128),
                        tag = c.String(nullable: false),
                        id_book = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_tag);
            
            AddColumn("dbo.Categories", "id_father", c => c.Int(nullable: false));
            AddColumn("dbo.Penalties", "days", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Penalties", "days");
            DropColumn("dbo.Categories", "id_father");
            DropTable("dbo.Tags");
            DropTable("dbo.AutBooks");
        }
    }
}
