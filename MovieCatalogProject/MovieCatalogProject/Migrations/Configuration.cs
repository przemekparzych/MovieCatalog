namespace MovieCatalogProject.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MovieCatalogProject.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MovieCatalogProject.Models.ApplicationDbContext context)
        { 
            context.Categories.AddOrUpdate(
              p => p.CategoryName,
              new Category { CategoryName = "Komedia" },
              new Category { CategoryName = "Akcja" },
              new Category { CategoryName = "Horror" },
              new Category { CategoryName = "Romantyczny" },
              new Category { CategoryName = "Dramat" }
            );
            context.CastTypes.AddOrUpdate(
                p => p.CastTypeName,
                new CastType { CastTypeName = "Director" },
                new CastType { CastTypeName = "Actor" },
                new CastType { CastTypeName = "Writer" }
                );
        }
    }
}

