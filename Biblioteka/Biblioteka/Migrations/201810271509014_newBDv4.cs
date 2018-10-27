namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newBDv4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "pesel", c => c.String(nullable: false, maxLength: 11));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accounts", "pesel", c => c.String(nullable: false));
        }
    }
}
