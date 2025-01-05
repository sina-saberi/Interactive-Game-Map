using Interactive_Map.Application.Delegates;
using Interactive_Map.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map.Application.Interfaces
{
    public interface IRepositoryBase<TEntity, TId> where TEntity : EntityBase<TId>
    {
        IQueryable<TEntity> AsQueryable();
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> exp);
        Task<TEntity> Get(TId id);
        Task<TEntity> Get(Expression<Func<TEntity, bool>> exp);
        Task Add(TEntity entity);
        Task AddRange(IEnumerable<TEntity> entities);
        Task Remove(TId id);
        Task Remove(Expression<Func<TEntity, bool>> exp);
        Task RemoveRange(Expression<Func<TEntity, bool>> exp);
        Task Update(TEntity entity);
        Task UpdateRange(IEnumerable<TEntity> entities);
        Task Merge(IEnumerable<TEntity> items, Func<TEntity, TEntity, bool> compareExpression, UpdateDelegate<TEntity, TId> updateExpression);
    }
}
