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
