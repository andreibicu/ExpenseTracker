using DataApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataApp.Core.Abstracts
{
    public interface IRepositoryFactory
    {
        IRepository<T> CreateRepository<T>(DbContext dbContext) where T : BaseEntity;
    }
}
