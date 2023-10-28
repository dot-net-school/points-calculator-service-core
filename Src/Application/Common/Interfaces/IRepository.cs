using System.Linq.Expressions;
using Domain.Common;

namespace Application.Common.Interfaces;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    void Update(TEntity entity);
    void Delete(TEntity entity);
    Task AddAsync(TEntity entity, CancellationToken cancellationToken);
    IQueryable<TEntity> GetAll();
    Task<TEntity> FindByIdAsync(object id, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
    Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    Task<TEntity> FirstOrDefaultAsNoTrackingAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

}
