namespace MovieCatalogProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gggg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VoteModels",
                c => new
                    {
                        AutoId = c.Int(nullable: false, identity: true),
                        Active = c.Boolean(nullable: false),
                        SectionId = c.Int(nullable: false),
                        UserName = c.String(),
                        Vote = c.Int(nullable: false),
                        VoteForId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AutoId);
            
            AddColumn("dbo.Movies", "Votes", c => c.String());
            AddColumn("dbo.Movies", "AutoId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "AutoId");
            DropColumn("dbo.Movies", "Votes");
            DropTable("dbo.VoteModels");
        }
    }
}
