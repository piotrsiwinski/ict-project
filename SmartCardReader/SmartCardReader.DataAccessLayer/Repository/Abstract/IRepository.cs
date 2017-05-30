using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SmartCardReader.DataAccessLayer.Repository.Abstract
{
    public interface IRepository<TEntity> where TEntity : class 
    {

        TEntity Get(int id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        void Edit(TEntity entity);
        void Save();
    }
}