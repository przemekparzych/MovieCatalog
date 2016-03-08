namespace MovieCatalogProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cccc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Casts",
                c => new
                    {
                        CastId = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        Person_FirstName = c.String(),
                        Person_LastName = c.String(),
                        CastTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CastId)
                .ForeignKey("dbo.CastTypes", t => t.CastTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.CastTypeId);
            
            CreateTable(
                "dbo.CastTypes",
                c => new
                    {
                        CastTypeId = c.Int(nullable: false, identity: true),
                        CastTypeName = c.String(),
                    })
                .PrimaryKey(t => t.CastTypeId);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        ProductionYear = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        PosterUrl = c.String(),
                        Votes = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.IdentityUsers", t => t.User_Id)
                .Index(t => t.CategoryId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        CommentContent = c.String(),
                        IdentityUserId = c.Int(nullable: false),
                        Movie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Movies", t => t.Movie_Id)
                .Index(t => t.Movie_Id);
            
            CreateTable(
                "dbo.IdentityUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IdentityUsers", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.IdentityUsers", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.IdentityUsers", t => t.IdentityUser_Id)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.VoteModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Active = c.Boolean(nullable: false),
                        SectionId = c.Int(nullable: false),
                        UserName = c.String(),
                        Vote = c.Int(nullable: false),
                        VoteForId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IdentityUsers", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Movies", "User_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.AspNetUserRoles", "IdentityUser_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.AspNetUserLogins", "IdentityUser_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.AspNetUserClaims", "IdentityUser_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.Comments", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.Movies", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Casts", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Casts", "CastTypeId", "dbo.CastTypes");
            DropIndex("dbo.AspNetUsers", new[] { "Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "IdentityUser_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "IdentityUser_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "IdentityUser_Id" });
            DropIndex("dbo.IdentityUsers", "UserNameIndex");
            DropIndex("dbo.Comments", new[] { "Movie_Id" });
            DropIndex("dbo.Movies", new[] { "User_Id" });
            DropIndex("dbo.Movies", new[] { "CategoryId" });
            DropIndex("dbo.Casts", new[] { "CastTypeId" });
            DropIndex("dbo.Casts", new[] { "MovieId" });
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.VoteModels");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.IdentityUsers");
            DropTable("dbo.Comments");
            DropTable("dbo.Categories");
            DropTable("dbo.Movies");
            DropTable("dbo.CastTypes");
            DropTable("dbo.Casts");
        }
    }
}
