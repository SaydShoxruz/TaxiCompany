using TaxiCompany.Core.Common;
using System.Collections;
using System.Linq.Expressions;

namespace TaxiCompany.DataAccess.Repositories.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate);

    Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
    IQueryable<TEntity> GetAll();
    IEnumerable<TEntity> GetAllAsEnumurable();

    Task<TEntity> AddAsync(TEntity entity);

    Task<TEntity> UpdateAsync(TEntity entity);

    Task<TEntity> DeleteAsync(TEntity entity);
    ValueTask<TEntity> InsertAsync(TEntity entity);
}
