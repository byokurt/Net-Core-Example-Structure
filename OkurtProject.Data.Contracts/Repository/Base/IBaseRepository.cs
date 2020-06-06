using OkurtProject.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OkurtProject.Data.Contracts
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        void Delete(TEntity entityToDelete);
        void Delete(object id);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        TEntity GetByID(object id);
        TEntity Insert(TEntity entity);
        void Insert(TEntity[] entity);
        void Update(TEntity entityToUpdate);
    }
}
