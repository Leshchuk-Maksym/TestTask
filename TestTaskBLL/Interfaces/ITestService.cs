using TestTaskDAL.Entities;

namespace TestTaskBLL.Interfaces
{
    public interface ITestService
    {
        Task<IEnumerable<Test>> GetAllAsync();
        Task<Test> GetByIdAsync(int id);
        Task<Test> AddAsync(Test entity);
        Task DeleteAsync(Test entity);
    }
}
