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
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            context.Categories.AddOrUpdate(
              p => p.CategoryName,
              new Category { CategoryName = "Komedia" },
              new Category { CategoryName = "Akcja" },
              new Category { CategoryName = "Dramat" }
            );
            context.CastTypes.AddOrUpdate(
                p => p.CastTypeName,
                new CastType { CastTypeName = "Re¿yser" },
                new CastType { CastTypeName = "Aktor" },
                new CastType { CastTypeName = "Producent" },
                new CastType { CastTypeName = "Scenarzysta" }
            );
        }
    }
}
