using Interactive_Map.Application.Interfaces;
using Interactive_Map.Domain.Base;
using Interactive_Map.Domain.Entities;
using Interactive_Map.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map.Infrastructure.Repositories
{
    public abstract class RepositoryBase<TEntity, TId>(GameMapsDbContext context) : IRepositoryBase<TEntity, TId> where TEntity : EntityBase<TId>
    {
        private readonly GameMapsDbContext _context = context;
        private readonly DbSet<TEntity> _entities = context.Set<TEntity>();

        public virtual IQueryable<TEntity> AsQueryable()
        {
            return _entities.AsQueryable();
        }

        public virtual async Task<TEntity> Get(TId id)
        {
            return await _entities.FirstAsync(x => x.Id!.Equals(id));
        }

        public virtual async Task<TEntity> Get(Func<TEntity, bool> exp)
        {
            return await _entities.FirstAsync(x => exp.Invoke(x));
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public virtual async Task Add(TEntity entity)
        {
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task AddRange(IEnumerable<TEntity> entities)
        {
            await _entities.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Remove(TId id)
        {
            var entity = await Get(id);
            if (entity != null)
            {
                _entities.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public virtual async Task Remove(Func<TEntity, bool> exp)
        {
            var entity = await Get(exp);
            if (entity != null)
            {
                _entities.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public virtual async Task Update(TEntity entity)
        {
            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task UpdateRange(IEnumerable<TEntity> entities)
        {
            _entities.UpdateRange(entities);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Merge(IEnumerable<TEntity> items, Func<TEntity, TEntity, bool> compareExpression)
        {
            var existingItems = _entities.ToList();

            var toAdd = items.Where(newItem => existingItems.All(existingItem => !compareExpression(existingItem, newItem))).ToList();

            var toUpdate = items.Where(newItem => existingItems.Any(existingItem => compareExpression(existingItem, newItem))).ToList();

            if (toAdd.Count != 0)
            {
                await AddRange(toAdd);
            }

            if (toUpdate.Count != 0)
            {
                foreach (var item in toUpdate)
                {
                    var existingItem = existingItems.First(e => compareExpression(e, item));
                    _context.Entry(existingItem).CurrentValues.SetValues(item);
                }

                await _context.SaveChangesAsync();
            }
        }
    }
}
