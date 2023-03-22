using TestTaskDAL.Entities;

namespace TestTaskBLL.Interfaces
{
    public interface IQuestionService
    {
        Task<IEnumerable<Question>> GetAllAsync();
        Task<Question> GetByIdAsync(int id);
        Task<IEnumerable<Question>> GetByTestIdAsync(int id);
        Task AddAsync(Question entity);
        Task DeleteAsync(Question entity);
        Task DeleteByIdAsync(int id);
    }
}
