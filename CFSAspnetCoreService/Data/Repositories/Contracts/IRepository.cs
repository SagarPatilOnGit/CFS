using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CFSAspnetCoreService.Data.Repositories.Contracts
{
    //Generic interface for application repos
    public interface IRepository<TEntity> where TEntity : class
    {
        //Finding objects
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity,bool>> predicates);
        //Adding objects
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        //Removing objects
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
