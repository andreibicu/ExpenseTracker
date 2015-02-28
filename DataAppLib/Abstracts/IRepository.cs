using DataApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataApp.Core.Abstracts
{
    public interface IRepository<T> : IDisposable where T : BaseEntity 
    {
        Boolean Add(T entity);
        Boolean Delete(T entity);
        Boolean Update(T entity);
        T Get(Func<T, Boolean> filter);
        List<T> GetAll(Func<T, Boolean> filter = null);
        void SaveChanges();
    }
}
