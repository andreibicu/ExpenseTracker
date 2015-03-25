using System;
using System.Data.Entity;
using DataApp.Core.DAL;
using DataApp.Core.Factories;
using DataApp.Core.Models;

namespace DataApp.Core.Abstracts
{
    public abstract class Controller<T>: IDisposable where T : class
    {
        protected IRepository<T> repo = null;
        protected DataAppContext dbContext = null;
        protected IRepositoryFactory factory = null;

        protected Controller()
        {
            this.dbContext = new DataAppContext();
            this.factory = new RepoFactory();
            this.repo = factory.CreateRepository<T>(this.dbContext);
        }

        public void Dispose()
        {
            this.repo.Dispose();
            this.dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }

    public interface IUserController : IAddData<User>, IModifyData<User>
    {
        User Login(String username, String password);
    }
}
