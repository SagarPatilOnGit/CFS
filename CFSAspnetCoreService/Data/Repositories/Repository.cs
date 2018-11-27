using CFSAspnetCoreService.Data.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CFSAspnetCoreService.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        //Marked protected so as to use this in derived entity repos
        protected readonly CfsContext _cfsContext;

        //ctor takes application dbcontext
        public Repository(CfsContext cfsContext)
        {
            _cfsContext = cfsContext;
        }
        
        //Finding entities
        public TEntity Get(int id)
        {
            return _cfsContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _cfsContext.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicates)
        {
            return _cfsContext.Set<TEntity>().Where(predicates);
        }

        //Adding entities
        public void Add(TEntity entity)
        {
            _cfsContext.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _cfsContext.AddRange(entities);
        }
        //Removing entities
        public void Remove(TEntity entity)
        {
            _cfsContext.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _cfsContext.RemoveRange(entities);
        }
    }
}
