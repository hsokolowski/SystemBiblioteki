namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class search_history1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Histories", "SearchDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Histories", "SearchDate");
        }
    }
}
