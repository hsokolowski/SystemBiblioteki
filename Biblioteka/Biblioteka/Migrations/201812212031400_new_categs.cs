namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_categs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "SubCategs", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "SubCategs");
        }
    }
}
