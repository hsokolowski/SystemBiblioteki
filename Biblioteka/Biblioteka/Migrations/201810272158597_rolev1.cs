namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rolev1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "TypeString", c => c.String());
            DropColumn("dbo.Accounts", "role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accounts", "role", c => c.Int(nullable: false));
            DropColumn("dbo.Accounts", "TypeString");
        }
    }
}
