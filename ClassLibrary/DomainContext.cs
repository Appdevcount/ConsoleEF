using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace ClassLibrary
{
    public class DomainContext : System.Data.Entity.DbContext
    {
        public DomainContext() : base("name=EFCF")
        {
            Database.SetInitializer<DomainContext>(new CustomDBInitializer());
        }
        public DbSet<ProfileDet> ProfDets { get; set; }
        public DbSet<GeneralTopics> GenTopics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new ProfileDetEntityConfiguration());
            modelBuilder.Configurations.Add(new GeneralTopicsEntityConfiguration());

        }

        private class CustomDBInitializer : CreateDatabaseIfNotExists<DomainContext> //IDatabaseInitializer<DomainContext>
        {
            protected override void Seed(DomainContext context)
            {
                base.Seed(context);
                //Can also seed data using configuration class seed method
                //Can also seed data by calling this DBInitializer in Contextclass contructor or in Application start event in Global.asax

                var pd = new List<ProfileDet> {
                new ProfileDet { ItemName = "seed1ini", Gender = Gender.Male//, ItemDescription = ""
                    ,ItemImage = null, InterestedTopicChecks = null, ItemType = "" },
                new ProfileDet { ItemName = "seed2ini", Gender = Gender.Male//, ItemDescription = ""
                , ItemImage = null, InterestedTopicChecks = null, ItemType = "" }
                };

                pd.ForEach(i => context.ProfDets.Add(i));
                context.SaveChanges();

                
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

}


////Code First Migrations

//http://www.entityframeworktutorial.net/code-first/code-based-migration-in-code-first.aspx

//Code-First has two commands for code based migration:

//Add-migration: It will scaffold the next migration for the changes you have made to your domain classes
//Update-database: It will apply pending changes to the database based on latest scaffolding code file you created using "Add-Migration" command

//Adding new column to table with default value by setting in migrations class method manually

    //AddColumn("dbo.Dogs", "BreedId", c => c.Int(nullable: false, defaultValue: 1));
   ////AddColumn("dbo.DemoRecords", "Created", c => c.DateTime());
   //AddColumn("dbo.DemoRecords", "Created", c => c.DateTime(defaultValueSql: "GETDATE()"));
   //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
   //public DateTime? Created { get; set; }


