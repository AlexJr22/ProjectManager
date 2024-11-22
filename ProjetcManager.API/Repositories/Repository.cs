
using Microsoft.EntityFrameworkCore;
using ProjetcManager.API.Data;
using System.Linq.Expressions;

namespace ProjetcManager.API.Repositories
{
    public class Repository<T>(AppDbContext context) : IRepository<T> where T : class
    {
        protected readonly AppDbContext _context = context;
        public async Task<IEnumerable<T>> GetAll()
        {
            var AllTask = await _context.Set<T>().AsNoTracking().ToListAsync();

            return AllTask;
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(expression);
        }

        public async Task<List<T>> GetByNameAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where<T>(expression).ToListAsync();
        }

        public T Create(T entity)
        {
            _context.Set<T>().Add(entity);

            return entity;
        }

        public T Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        public T Delete(T entity)
        {
            _context.Set<T>().Remove(entity);

            return entity;
        }
    }
}
