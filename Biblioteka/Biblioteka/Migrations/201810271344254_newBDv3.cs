namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newBDv3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "pesel", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accounts", "pesel", c => c.String(nullable: false, maxLength: 11));
        }
    }
}
