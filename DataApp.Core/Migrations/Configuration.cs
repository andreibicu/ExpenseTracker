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

            #region Vouchers
            context.Vouchers.AddOrUpdate(
                u => u.Id,
                new Voucher { Id = 1 ,AddedOn=DateTime.Now,IsExpense=false,IssuedOn=DateTime.Now,Notes="Default Voucher",TransactionAccountId=1}
            );

            context.SaveChanges();
            #endregion

            #region Checks
            context.Checks.AddOrUpdate(
                u => u.Id,
                new Check { Id = 1,AddedOn=DateTime.Now, Amount=0,Notes = "Default Check",TransactionAccountId=1}
            );

            context.SaveChanges();
            #endregion

            #region CheckTransactions
            context.CheckTransactions.AddOrUpdate(
                u => u.Id,
                new CheckTransaction { Id = 1, Amount = 0, Notes = "Default Check Transaction",CheckId=1,VoucherId=1 }
            );

            context.SaveChanges();
            #endregion

            #region Expenses
            context.Expenses.AddOrUpdate(
                u => u.Id,
                new Expense { Id = 1, VoucherId = 1 }
            );

            context.SaveChanges();
            #endregion

            #region ExpenseItems
            context.ExpenseItems.AddOrUpdate(
                u => u.Id,
                new ExpenseItem { Id = 1, Amount = 0, Notes = "Default Expense Item", Category=Enums.ExpenseCategory.CashAdvance,ExpenseId = 1,ORNumber="NA",PurchaseDate=DateTime.Now,TransactionAccountId=1,ProjectId=1 }
            );

            context.SaveChanges();
            #endregion


        }
    }
}
