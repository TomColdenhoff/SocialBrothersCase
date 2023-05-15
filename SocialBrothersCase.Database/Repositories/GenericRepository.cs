using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SocialBrothersCase.Database.Extensions;

namespace SocialBrothersCase.Database.Repositories;

public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly AddressContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public GenericRepository(AddressContext context)
    {
        this._context = context;
        this._dbSet = context.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> GetAsync(string? filter = null, string? orderByProperty = null, bool descending = false, string includeProperties = "")
    {
        var query = _dbSet.Where(entity => true);

        if (filter != null)
        {
            query = query.Filter(filter);
            // var stringProperties = typeof(TEntity).GetProperties().Where(prop =>
            //     prop.PropertyType == filter.GetType());
            //
            // foreach (var stringProperty in stringProperties)
            // {
            //     var val = Expression.Parameter(typeof(TEntity), stringProperty.Name);
            //     var property = val == "";
            //     query = query.Where(ent => ent.GetType() == null);
            // }
            //
            // // query = query.Where(entity => 
            // //     stringProperties.Any(property => EF.Property<string>(entity, property.Name) == filter));
            // var dd = query.ToQueryString();
        }

        foreach (var includeProperty in includeProperties.Split
                     (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        if (!string.IsNullOrWhiteSpace(orderByProperty))
        {
            query = query.OrderBy(orderByProperty, descending);
        }

        // return orderBy != null ? await orderBy(query).ToListAsync() : await query.ToListAsync();
        return await query.ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string includeProperties = "")
    {
        IQueryable<TEntity> query = _dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties.Split
                     (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        return orderBy != null ? await orderBy(query).ToListAsync() : await query.ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(object id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task InsertAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task<bool> DeleteAsync(object id)
    {
        var entityToDelete = await _dbSet.FindAsync(id);

        if (entityToDelete == null) return false;
        
        Delete(entityToDelete);
        return true;
    }

    public void Delete(TEntity entityToDelete)
    {
        if (_context.Entry(entityToDelete).State == EntityState.Detached)
        {
            _dbSet.Attach(entityToDelete);
        }
        _dbSet.Remove(entityToDelete);
    }

    public void Update(TEntity entityToUpdate)
    {
        _dbSet.Attach(entityToUpdate);
        _context.Entry(entityToUpdate).State = EntityState.Modified;
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}