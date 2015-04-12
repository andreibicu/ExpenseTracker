using System.Data.Entity;
using DataApp.Core.Models;
namespace DataApp.Core.DAL
{


    public class DataAppContext : DbContext
    {
        public DataAppContext()
            : base("name=DataAppDB")
        {
            //this.Database.Initialize(force: true);
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<TransactionAccount> TransactionAccounts { get; set; }
        public virtual DbSet<CheckVoucher> CheckVouchers { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }

        //depreciated
        //public virtual DbSet<Voucher> Vouchers { get; set; }
        //public virtual DbSet<Check> Checks { get; set; }
        //public virtual DbSet<CheckTransaction> CheckTransactions { get; set; }
        //public virtual DbSet<ExpenseItem> ExpenseItems { get; set; }
    }

}