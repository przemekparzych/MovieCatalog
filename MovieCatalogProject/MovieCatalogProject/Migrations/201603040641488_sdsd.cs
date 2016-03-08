namespace MovieCatalogProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdsd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.Comments", new[] { "Movie_Id" });
            RenameColumn(table: "dbo.Comments", name: "Movie_Id", newName: "MovieId");
            AddColumn("dbo.Comments", "UserName", c => c.String());
            AlterColumn("dbo.Comments", "MovieId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "MovieId");
            AddForeignKey("dbo.Comments", "MovieId", "dbo.Movies", "Id", cascadeDelete: true);
            DropColumn("dbo.Comments", "IdentityUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "IdentityUserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Comments", "MovieId", "dbo.Movies");
            DropIndex("dbo.Comments", new[] { "MovieId" });
            AlterColumn("dbo.Comments", "MovieId", c => c.Int());
            DropColumn("dbo.Comments", "UserName");
            RenameColumn(table: "dbo.Comments", name: "MovieId", newName: "Movie_Id");
            CreateIndex("dbo.Comments", "Movie_Id");
            AddForeignKey("dbo.Comments", "Movie_Id", "dbo.Movies", "Id");
        }
    }
}
