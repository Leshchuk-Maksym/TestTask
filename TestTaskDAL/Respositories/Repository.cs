using Microsoft.EntityFrameworkCore;
using TestTaskDAL.Context;
using TestTaskDAL.Entities;
using TestTaskDAL.Interfaces;

namespace TestTaskDAL.Respositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : IEntity
    {
        public TestTaskContext _context;

        public Repository(TestTaskContext context)
        {
            _context = context;
        }

        public virtual IQueryable<TEntity> All()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FirstAsync(x => x.Id == id);
        }
        public async Task DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }


    }
}
