using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataApp.Core.Abstracts;
using DataApp.Core.Repositories;
namespace DataApp.Core.Factories
{
    public class RepoFactory:IRepositoryFactory
    {
        public IRepository<T> CreateRepository<T>(System.Data.Entity.DbContext dbContext) where T : Models.BaseEntity
        {
            return new GenericRepository<T>(dbContext);
        }
    }
}
