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
            context.CustomerUsers.AddOrUpdate(c => c.UserId,
                new CustomerUsers() { CustomerId = 4, FirstName = "Graham", LastName = "Schenk", PhoneNumber = "4493829" },
                new CustomerUsers() { CustomerId = 5, FirstName = "Shelly", LastName = "Erickson", PhoneNumber = "3882034" },
                new CustomerUsers() { CustomerId = 6, FirstName = "Charles", LastName = "Chance", PhoneNumber = "4883920" }
            );


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
