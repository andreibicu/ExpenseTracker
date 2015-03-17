namespace DataApp.Core.Migrations
{
    using System.Data.Entity.Migrations;
    using DataApp.Core.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<DataApp.Core.DAL.DataAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "DataApp.Core.DAL.DataAppContext";
        }

        protected override void Seed(DataApp.Core.DAL.DataAppContext context)
        {
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

            context.Users.AddOrUpdate(
                u => u.Username,
                new User { Username = "root",Password="toor"}
            );
        }
    }
}
