using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DataApp.Core.Abstracts;
using DataApp.Core.Models;

namespace DataApp.Core.Repositories
{
    class GenericRepository<T> : IRepository<T> where T : class
    {
        protected DbContext dbContext = null;

        public GenericRepository(DbContext context)
        {
            this.dbContext = context;
        }

        #region CRUD
        public bool Add(T entity)
        {
            this.dbContext.Set<T>().Add(entity);
            //added logic
            this.SaveChanges();
            return true;
        }

        public bool Delete(T entity)
        {
            this.dbContext.Set<T>().Attach(entity);
            this.dbContext.Entry<T>(entity).State = EntityState.Modified;
            this.SaveChanges();
            return true;
        }

        public bool Update(T entity)
        {
            this.dbContext.Set<T>().Remove(entity);
            this.SaveChanges();
            return true;
        }

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        } 

        #region READ
        public T Get(object id)
        {
            return this.dbContext.Set<T>().Find(id);
        }

        public List<T> Get(Func<T, bool> filter = null)
        {
            if (filter == null)
                return this.dbContext.Set<T>().AsNoTracking().ToList();
            else
                return this.dbContext.Set<T>().AsNoTracking().Where(filter).ToList();
        } 
        #endregion
        #endregion

        #region CRUD ASYNC
        //public async Task<List<T>> GetAllAsync(Func<T, bool> filter = null)
        //{
        //    if (filter == null)
        //        return await this.dbContext.Set<T>().ToListAsync();
        //    else
        //        return this.dbContext.Set<T>().Where(filter).ToList();
        //} 

        #endregion

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
