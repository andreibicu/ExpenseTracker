using DataApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataApp.Core.Abstracts
{
    public interface IRepository<T> :IReadData<T>,IAddData<T>,IModifyData<T>,IRemoveData<T>,  IDisposable where T : BaseEntity 
    {
        void SaveChanges();
    }

    public interface IReadData<T>  where T : BaseEntity
    {
        T Get(Func<T, Boolean> filter);
        List<T> GetAll(Func<T, Boolean> filter = null);
    }

    public interface IModifyData<T> where T : BaseEntity
    {
        Boolean Update(T entity);
    }

    public interface IAddData<T> where T : BaseEntity
    {
        Boolean Add(T entity);        
    }

    public interface IRemoveData<T> where T : BaseEntity
    {
        Boolean Delete(T entity);
    }
}
