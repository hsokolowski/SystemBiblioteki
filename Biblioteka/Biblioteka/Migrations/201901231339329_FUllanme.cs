namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FUllanme : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "FullName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authors", "FullName");
        }
    }
}
