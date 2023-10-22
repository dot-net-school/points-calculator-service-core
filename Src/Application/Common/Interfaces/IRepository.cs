using System.Linq.Expressions;

namespace Application.Common.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    void Update(TEntity entity);
    void Delete(TEntity entity);
    Task AddAsync(TEntity entity, CancellationToken cancellationToken);
    IQueryable<TEntity> GetAll();

    Task<TEntity> FindByIdAsync(object id, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
    Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

    //Task<bool> ExistsAsync(object id, CancellationToken cancellationToken);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

}
