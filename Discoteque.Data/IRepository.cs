using System.Linq.Expressions;
using Discoteque.Data.Models;

namespace Discoteque.Data.IRepositories
{

    public interface IRepository<Tid, TEntity>
    where Tid : struct
    where TEntity : BaseEntity<Tid>
    {
        Task AddAsync(TEntity entity);
        Task<TEntity> FindAsync(Tid id);
        Task<IEnumerable<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> filter =  null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task Delete(Tid id);
    }
}