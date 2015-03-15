using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataApp.Core.Abstracts;
using DataApp.Core.DAL;
using DataApp.Core.Models;
using DataApp.Core.Factories;
using System.Data.Entity;

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
