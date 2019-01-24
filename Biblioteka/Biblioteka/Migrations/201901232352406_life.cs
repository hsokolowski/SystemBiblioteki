namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class life : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Longlives", "limit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Longlives", "limit");
        }
    }
}
