namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rolev12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "Role", c => c.Int(nullable: false));
            DropColumn("dbo.Accounts", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accounts", "Type", c => c.Int(nullable: false));
            DropColumn("dbo.Accounts", "Role");
        }
    }
}
