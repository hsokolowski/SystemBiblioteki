namespace Biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class repo : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Repositories");
            AlterColumn("dbo.Repositories", "RepositoryID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Repositories", "RepositoryID");
            CreateIndex("dbo.Repositories", "RepositoryID");
            AddForeignKey("dbo.Repositories", "RepositoryID", "dbo.Books", "BookID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Repositories", "RepositoryID", "dbo.Books");
            DropIndex("dbo.Repositories", new[] { "RepositoryID" });
            DropPrimaryKey("dbo.Repositories");
            AlterColumn("dbo.Repositories", "RepositoryID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Repositories", "RepositoryID");
        }
    }
}
