using MvcOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvcOnion.Domain.IRepositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<bool> Create(TEntity entity);

        Task<bool> Update(TEntity entity);

        Task<bool> Delete(TEntity entity);

        Task<TEntity> GetById(int id);
        
        Task<IEnumerable<TEntity>> GetFilteredAll(Expression<Func<TEntity, bool>> filter = null!);

    }
}
