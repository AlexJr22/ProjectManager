using System.Linq.Expressions;

namespace ProjetcManager.API;

public interface IRepository<T>
{
    Task<IEnumerable<T>> GetAllTask();
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
    T Create(T Entity);
    T UpdateTask(T Entity);
    T DeleteTask(T Entity);
}
