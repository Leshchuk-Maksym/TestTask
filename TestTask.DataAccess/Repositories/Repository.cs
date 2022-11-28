using Microsoft.EntityFrameworkCore;
using TestTask.DataAccess.Context;
using TestTask.DataAccess.Interfaces;

namespace TestTask.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public TestTaskContext _context;
        public Repository(TestTaskContext context)
        {
            _context = context;
        }

        public virtual IQueryable<T> All()
        {
            return _context.Set<T>().AsQueryable();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByKeyAsync(string key)
        {
            return await _context.Set<T>().FindAsync(key);
        }

        public virtual async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task RemoveAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
