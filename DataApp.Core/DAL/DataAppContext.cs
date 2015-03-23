using System.Data.Entity;
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
            : base("DataAppContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<TransactionAccount> TransactionAccounts { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }
        public virtual DbSet<Check> Checks { get; set; }
        public virtual DbSet<CheckTransaction> CheckTransactions { get; set; }
        public virtual DbSet<ExpenseItem> ExpenseItems { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<Project> Projects { get; set; }


    }

}