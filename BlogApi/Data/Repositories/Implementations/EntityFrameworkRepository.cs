using System.Linq.Expressions;
using BlogApi.Data.Repositories.Contract;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Data.Repositories.Implementations;

public class EntityFrameworkRepository<T> : IRepository<T> where T : class
{

    private readonly ApplicationContext _context;

    private readonly DbSet<T> _dbSet;

    public EntityFrameworkRepository(ApplicationContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<T> GetById(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> Add(T entity)
    {
        _dbSet.Add(entity);

        await _context.SaveChangesAsync();

        return entity;

    }

    public async Task<T> Delete(T entity)
    {
        _dbSet.Remove(entity);

        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<T> Update(T entity, T newEntity)
    {
        _context.Entry(entity).State = EntityState.Modified;

        _context.Entry(entity).CurrentValues.SetValues(newEntity);

        await _context.SaveChangesAsync();

        return entity;
    }

    public IQueryable<T> Queryable()
    {
        return _dbSet.AsQueryable();
    }

    public async Task<bool> Any(Expression<Func<T, bool>> predicate = null)
    {
        return await _dbSet.AnyAsync(predicate);
    }


    public async Task AddRange(IEnumerable<T> entities)
    {
        _dbSet.AddRange(entities);
        await _context.SaveChangesAsync();
    }
}


