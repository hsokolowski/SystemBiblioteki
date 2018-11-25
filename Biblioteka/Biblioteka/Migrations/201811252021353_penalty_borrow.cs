namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class penalty_borrow : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "Penalty_PenaltyID", "dbo.Penalties");
            DropIndex("dbo.Books", new[] { "Penalty_PenaltyID" });
            DropColumn("dbo.Books", "Penalty_PenaltyID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Penalty_PenaltyID", c => c.Int());
            CreateIndex("dbo.Books", "Penalty_PenaltyID");
            AddForeignKey("dbo.Books", "Penalty_PenaltyID", "dbo.Penalties", "PenaltyID");
        }
    }
}
