using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DataApp.Core.Abstracts;
using DataApp.Core.DAL;
using DataApp.Core.Models;
using DataApp.Core.Factories;

namespace DataApp.Core.Abstracts
{
    public abstract class Controller<T>: IDisposable where T : BaseEntity 
    {
        protected IRepository<T> repo = null;
        protected DbContext dbContext = null;
        protected IRepositoryFactory factory = null;

        public Controller()
        {
            this.dbContext = new DataAppContext();
            this.factory = new RepoFactory();
            this.repo = factory.CreateRepository<T>(this.dbContext);
        }

        public void Dispose()
        {
            this.repo.Dispose();
            this.dbContext.Dispose();
        }
    }

    public interface IUserController : IAddData<User>, IModifyData<User>
    {
        User Login(String username, String password);
    }
}
