namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_categs2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "SubCategs", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "SubCategs", c => c.String());
        }
    }
}
