namespace TestTaskDAL.Interfaces
{
    public interface IRepository<IEntity>
    {
        IQueryable<IEntity> All();

        Task<IEnumerable<IEntity>> GetAllAsync();
        Task<IEntity> GetByIdAsync(int id);
        Task AddAsync(IEntity entity);
        Task DeleteAsync(IEntity entity);
        Task SaveChangesAsync();
    }
}
