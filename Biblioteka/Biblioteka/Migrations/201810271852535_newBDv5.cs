namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newBDv5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "id_author", c => c.Int(nullable: false));
            AddColumn("dbo.Queues", "id_book", c => c.Int(nullable: false));
            DropColumn("dbo.Books", "authorID");
            DropColumn("dbo.Positions", "condition");
            DropColumn("dbo.Queues", "ISBN");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Queues", "ISBN", c => c.Int(nullable: false));
            AddColumn("dbo.Positions", "condition", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "authorID", c => c.Int(nullable: false));
            DropColumn("dbo.Queues", "id_book");
            DropColumn("dbo.Books", "id_author");
        }
    }
}
