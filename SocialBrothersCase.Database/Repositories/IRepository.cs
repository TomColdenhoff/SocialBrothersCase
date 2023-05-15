using System.Linq.Expressions;

namespace SocialBrothersCase.Database.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    public Task<IEnumerable<TEntity>> GetAsync(
        string? filter = null,
        string? orderByProperty = null,
        bool descending = false,
        string includeProperties = "");

    public Task<IEnumerable<TEntity>> GetAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string includeProperties = "");

    public Task<TEntity?> GetByIdAsync(object id);

    public Task InsertAsync(TEntity entity);

    public Task<bool> DeleteAsync(object id);

    public void Delete(TEntity entityToDelete);

    public void Update(TEntity entityToUpdate);

    public Task SaveAsync();
}