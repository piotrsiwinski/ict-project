using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using SmartCardReader.DataAccessLayer.Concrete;

namespace SmartCardReader.DataAccessLayer.Repository.Abstract
{
    public class AbstractRepository<T> : IRepository<T> where T : class
    {
        protected readonly EfDbContext Context;

        public AbstractRepository(EfDbContext context)
        {
            Context = context;
        }

        public T Get(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return Context.Set<T>();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate);
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            Context.Set<T>().AddRange(entities);
        }

        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            Context.Set<T>().RemoveRange(entities);
        }

        public void Edit(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}