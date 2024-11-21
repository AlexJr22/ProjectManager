using System.Linq.Expressions;

namespace ProjetcManager.API;

public interface IRepository<T>
{
    Task<IEnumerable<T>> GetAllTask();
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
    Task<List<T>> GetByNameAsync(Expression<Func<T, bool>> predicate);
    T Create(T Entity);
    T Update(T Entity);
    T Delete(T Entity);
}
