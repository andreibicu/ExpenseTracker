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
        protected DbContext dbContext = null;
        protected IRepositoryFactory factory = null;

        public DataAppFacade()
        {
            this.factory = new RepoFactory();
            this.dbContext = new DataAppContext();
        }

        public CheckController CheckController { get { return new CheckController(); } }
        public VoucherController VoucherController { get { return new VoucherController(); } }
        public ExpenseController ExpenseController { get { return new ExpenseController(); } }


        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
