using System;
using System.Data.Entity;
using DataApp.Core.Abstracts;
using DataApp.Core.DAL;
using DataApp.Core.Factories;
using DataApp.Core.Models;
using DataApp.Core.Controllers;
namespace DataApp.Core
{
    public class DataAppFacade:IDisposable
    {
        protected DataAppContext dbContext = null;
        protected IRepositoryFactory factory = null;

        public DataAppFacade()
        {
            this.factory = new RepoFactory();
            this.dbContext = new DataAppContext();
        }

        //public UserController UserController { get { return new UserController(this.dbContext); } }
        //public CheckController CheckController { get { return new CheckController(this.dbContext); } }
        //public VoucherController VoucherController { get { return new VoucherController(this.dbContext); } }
        public ExpenseController ExpenseController { get { return new ExpenseController(this.dbContext); } }
        public ProjectController ProjectController { get { return new ProjectController(this.dbContext); } }
        public CheckVoucherController CheckVoucherController { get { return new CheckVoucherController(this.dbContext); } }

        //public CheckTransactionController CheckTransactionController { get { return new CheckTransactionController(this.dbContext); } }
        //public ExpenseItemController ExpenseItemController { get { return new ExpenseItemController(this.dbContext); } }

        public TransactionAccountController TransactionAccountController { get { return new TransactionAccountController(this.dbContext); } }

        
        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
