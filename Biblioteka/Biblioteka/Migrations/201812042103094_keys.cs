namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class keys : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "for_who_string", c => c.String());
            DropColumn("dbo.Books", "for_who");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "for_who", c => c.String());
            DropColumn("dbo.Books", "for_who_string");
        }
    }
}
