namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rolev11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "Type", c => c.Int(nullable: false));
            DropColumn("dbo.Accounts", "TypeString");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accounts", "TypeString", c => c.String());
            DropColumn("dbo.Accounts", "Type");
        }
    }
}
