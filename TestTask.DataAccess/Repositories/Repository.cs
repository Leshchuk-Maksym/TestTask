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

        /// <summary>
        /// Gets T context.
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<T> All()
        {
            return _context.Set<T>().AsQueryable();
        }

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        /// <summary>
        /// Gets entity by identifier asynchronosly.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual async Task<T> GetByKeyAsync(string key)
        {
            return await _context.Set<T>().FindAsync(key);
        }

        /// <summary>
        /// Adds entity asynchronosly.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates entity asynchronosly.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Removes entity asynchronosly.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task RemoveAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
