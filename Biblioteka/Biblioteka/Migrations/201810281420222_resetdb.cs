namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resetdb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Borrowings", "id_queue", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Borrowings", "id_queue");
        }
    }
}
