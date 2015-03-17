using System.Data.Entity;
using DataApp.Core.Models;

namespace DataApp.Core.Abstracts
{
    public interface IRepositoryFactory
    {
        IRepository<T> CreateRepository<T>(DbContext dbContext) where T : BaseEntity;
    }
}
