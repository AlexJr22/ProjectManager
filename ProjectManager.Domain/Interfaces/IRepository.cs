using ProjectManager.Domain.Entities;
using System.Linq.Expressions;

namespace ProjectManager.Domain.Interfaces;

public interface IRepository<T>
{
    Task<T?> GetAsync(Expression<Func<T, bool>> expression);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> CreateAsync(T entity);
    T Update(T entity);
    T Delete(T entity);
}
