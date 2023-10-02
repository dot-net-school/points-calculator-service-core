namespace Application.Common.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    void Update(TEntity entity);
    void DeleteAsync(TEntity entity);
    Task AddAsync(TEntity entity);
    IQueryable<TEntity> GetAll();
    Task<TEntity> GetByIdAsync(object id);
    Task SaveChangesAsync();
}
