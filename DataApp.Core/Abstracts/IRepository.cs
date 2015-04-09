using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataApp.Core.Models;

namespace DataApp.Core.Abstracts
{
    public interface IRepository<T> :
        IReadData<T>,IAddData<T>,IModifyData<T>,IRemoveData<T>,  //CRUD
        //IReadDataAsync<T>,//CRUD ASYNC
        IDisposable where T : class  
    {
        void SaveChanges();
    }

    public interface IReadData<T> where T : class
    {
        //T Get(Func<T, Boolean> filter);
        //List<T> GetAll(Func<T, Boolean> filter = null);

        T Get(object id);
        List<T> Get(Func<T, Boolean> filter = null);
    }

    public interface IModifyData<T> where T : class
    {
        Boolean Update(T entity);
    }

    public interface IAddData<T> where T : class
    {
        Boolean Add(T entity);        
    }

    public interface IRemoveData<T> where T : class
    {
        Boolean Delete(T entity);
    }

    //public interface IReadDataAsync<T> where T : class
    //{
    //    //Task<T> GetAsync(Func<T, Boolean> filter); //Problem with dbContext.Set<T>().FirstOrDefaultAsync(filter);
    //    Task<List<T>> GetAllAsync(Func<T, Boolean> filter = null);
    //}
}
