namespace TestTask.DataAccess.Interfaces
{
    public interface IRepository<T>
    {
        Task AddAsync(T entity);
        IQueryable<T> All();
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByKeyAsync(string key);
        Task RemoveAsync(T entity);
        Task UpdateAsync(T entity);
    }
}