using System.Data.Entity;
using DataApp.Core.Abstracts;
using DataApp.Core.DAL;
using DataApp.Core.Factories;
using DataApp.Core.Models;

namespace DataApp.Core
{
    public class DataAppFacade
    {
        protected DbContext dbContext = null;
        protected IRepositoryFactory factory = null;

        public DataAppFacade()
        {
            this.factory = new RepoFactory();
            this.dbContext = new DataAppContext();
        }

        public IRepository<User> ProjectRepo { get { return this.factory.CreateRepository<User>(this.dbContext); } }
    }
}
