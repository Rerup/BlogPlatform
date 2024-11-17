using System.Linq.Expressions;

namespace BlogApi.Data.Repositories.Contract;

public interface IRepository<T>
{
    Task<T> GetById(int id);

    Task<IEnumerable<T>> GetAll();

    Task<T> Add(T entity);

    Task<T> Update(T entity, T newEntity);

    Task<T> Delete(T entity);

    Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);

    Task<IEnumerable<T>> GetWithIncludes(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

}
