using TestTaskDAL.Entities;

namespace TestTaskBLL.Interfaces
{
    public interface ITestService
    {
        Task<IEnumerable<Test>> GetAllAsync();
        Task<Test> GetByIdAsync(int id);
        Task AddAsync(Test entity);
        Task DeleteByIdAsync(int id);
    }
}
