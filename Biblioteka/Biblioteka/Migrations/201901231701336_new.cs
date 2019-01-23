namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Longlives",
                c => new
                    {
                        LonglifeID = c.Int(nullable: false, identity: true),
                        longlife = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LonglifeID);
            
            AddColumn("dbo.Authors", "FullName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authors", "FullName");
            DropTable("dbo.Longlives");
        }
    }
}
