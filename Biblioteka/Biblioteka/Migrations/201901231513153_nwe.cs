namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nwe : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Longlives");
        }
    }
}