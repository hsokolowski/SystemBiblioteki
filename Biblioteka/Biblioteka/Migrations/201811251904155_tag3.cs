namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tag3 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Tags");
            AlterColumn("dbo.Tags", "TagID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Tags", "TagID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Tags");
            AlterColumn("dbo.Tags", "TagID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Tags", "TagID");
        }
    }
}
