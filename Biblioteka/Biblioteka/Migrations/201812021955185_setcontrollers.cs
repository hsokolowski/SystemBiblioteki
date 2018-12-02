namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setcontrollers : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Authors", "Country");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Authors", "Country", c => c.String(nullable: false));
        }
    }
}
