namespace ClassLibrary.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ClassLibrary.DomainContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false; //whats is automatic migrations
        }

        protected override void Seed(ClassLibrary.DomainContext context)
        {
            context.ProfDets.AddOrUpdate(
                new ProfileDet { ItemName = "seed1", Gender = Gender.Male//, ItemDescription = ""
                , ItemImage = null, InterestedTopicChecks = null, ItemType = "" },
                new ProfileDet { ItemName = "seed2", Gender = Gender.Male//, ItemDescription = ""
                , ItemImage = null, InterestedTopicChecks = null, ItemType = "" }
            );
            context.SaveChanges();

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
