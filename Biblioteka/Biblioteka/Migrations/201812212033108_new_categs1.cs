namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_categs1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "SubCategs", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "SubCategs", c => c.Int(nullable: false));
        }
    }
}
