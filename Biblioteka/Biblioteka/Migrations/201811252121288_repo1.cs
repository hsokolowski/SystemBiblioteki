namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class repo1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Repositories", "Amount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Repositories", "Amount");
        }
    }
}
