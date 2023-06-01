using Microsoft.EntityFrameworkCore;
using MvcOnion.Domain.Entities;
using MvcOnion.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvcOnion.Infrustructure.Repositories
{
    public class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : BaseEntity
        where TContext : DbContext
    {
        private readonly TContext _context;

        public BaseRepository(TContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(TEntity entity)
        {
            //_context.Entry(entity).State = EntityState.Added;
            await _context.Set<TEntity>().AddAsync(entity);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(TEntity entity)
        {
            bool hasIsActive = HasOwnProperty(typeof(TEntity), "IsActive");

            if (hasIsActive)
            {
                entity.IsActive = false;
                return await Update(entity);
            }
            else
            {
                //_context.Entry(entity).State = EntityState.Deleted;
                _context.Set<TEntity>().Remove(entity);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        private bool HasOwnProperty(Type type, string propertyName)
        {
            bool hasOwnProperty = type.GetProperties().Any(p => p.Name == propertyName);
            return hasOwnProperty;
        }

        public async Task<TEntity?> GetById(int id)
        {
            return await _context.Set<TEntity>()
                                 .FirstOrDefaultAsync(x => x.Id == id && x.IsActive);
        }

        public async Task<IEnumerable<TEntity>> GetFilteredAll(Expression<Func<TEntity, bool>> filter = null!)
        {
            return filter != null ? await _context.Set<TEntity>().Where(filter).ToListAsync()
                : await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<bool> Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            //_context.Set<TEntity>().Update(entity);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
