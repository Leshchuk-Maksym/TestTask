using TestTaskDAL.Entities;

namespace TestTaskBLL.Interfaces
{
    public interface ITestService
    {
        Task<IEnumerable<Test>> GetAllAsync();
        Task<Test> GetByIdAsync(int id);
        Task<IEnumerable<Test>> GetByUserIdAsync(int id);
        Task AddAsync(Test entity);
        Task UpdateAsync(Test entity);
        Task UpdateBestScoreAsync(double score, int id);
        Task DeleteByIdAsync(int id);
    }
}
