namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TrashCollector.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TrashCollector.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TrashCollector.Models.ApplicationDbContext context)
        {
            //States Wisconsin = new States()
            //{
            //    StateName = "Wisconsin",
            //    StateAbbreviation = "WI"
            //};

            //context.States.Add(Wisconsin);

            //Cities Milwaukee = new Cities() { CityName = "Milwaukee" };
            ////Cities Brookfield = new Cities() { CityName = "Brookfield" };
            ////Cities NewBerlin = new Cities() { CityName = "New Berlin" };
            ////Cities Wauwatosa = new Cities() { CityName = "Wauwatosa" };

            //context.Cities.Add(Milwaukee);
            //context.Cities.Add(Brookfield);
            //context.Cities.Add(NewBerlin);
            //context.Cities.Add(Wauwatosa);
            
            
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
