using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using DataApp.Core.Models;
namespace DataApp.Core.DAL
{


    public class DataAppContext : DbContext
    {
        // Your context has been configured to use a 'DataAppContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DataApp.Core.DAL.DataAppContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DataAppContext' 
        // connection string in the application configuration file.
        public DataAppContext()
            : base("name=DataAppContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataAppContext, Configuration>("name=DataAppContext"));
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Voucher> Vouchers { get; set; }
        public virtual DbSet<Check> Checks { get; set; }
        public virtual DbSet<CheckTransaction> CheckTransactions { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<ExpenseItem> ExpenseItems { get; set; }
        public virtual DbSet<Project> Projects { get; set; }



        public virtual DbSet<User> Users { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }

    internal sealed class Configuration : DbMigrationsConfiguration<DataAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataAppContext context)
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
        }
    }

}