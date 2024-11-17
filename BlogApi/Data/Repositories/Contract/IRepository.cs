using System.Linq.Expressions;

namespace BlogApi.Data.Repositories.Contract;

public interface IRepository<T>
{
    Task<T> GetById(int id);

    Task<IEnumerable<T>> GetAll();

    void Add(T entity);

    void Update(T entity);

    void Delete(T entity);

    Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);

    Task<IEnumerable<T>> GetWithIncludes(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

}
