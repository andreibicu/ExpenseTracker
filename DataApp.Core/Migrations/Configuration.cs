using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using DataApp.Core.Models;
namespace DataApp.Core.Migrations
{


    internal sealed class Configuration : DbMigrationsConfiguration<DataApp.Core.DAL.DataAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DataApp.Core.DAL.DataAppContext context)
        {
            //  This method will be called after migrating to the latest version.

            #region Users
            context.Users.AddOrUpdate(
                u => u.Id,
                new User { Id = 1, Username = "root", Password = "toor" }
            );

            context.SaveChanges(); 
            #endregion

            #region TransactionAccounts
            context.TransactionAccounts.AddOrUpdate(
                u => u.Id,
                new TransactionAccount { Id = 1, Name="N/A",Notes="Default Account" }
            );

            context.SaveChanges();
            #endregion

            #region Projects
            context.Projects.AddOrUpdate(
                u => u.Id,
                new Project { Id = 1,Notes = "Default Project",Name="N/A"}
            );

            context.SaveChanges();
            #endregion

            #region CheckVoucher
            context.CheckVouchers.AddOrUpdate(
                u => u.Id,
                new CheckVoucher { Id = 1, Notes = "N/A", Amount=0,CheckNo="N/A",DueDate=DateTime.Now.Date,EntryDate = DateTime.Now.Date,PayeeId=1 }
            );
            context.SaveChanges();
            #endregion

            #region Expenses
            context.Expenses.AddOrUpdate(
                u => u.Id,
                new Expense { Id = 1, Notes = "N/A", Category=Enums.ExpenseCategory.MISC,CompanyId=1,ORNumber="N/A",ProjectId=1,PurchaseDate=DateTime.Now.Date,CheckVoucherID =1}
            );

            context.SaveChanges();
            #endregion


        }
    }
}
