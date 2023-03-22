using Microsoft.EntityFrameworkCore;
using TestTaskBLL.Interfaces;
using TestTaskDAL.Entities;
using TestTaskDAL.Interfaces;

namespace TestTaskBLL.Services
{
    public class TestService : ITestService
    {
        private readonly IRepository<Test> testRepository;
        private readonly IRepository<Question> questionRepository;
        private readonly IRepository<Answer> answerRepository;

        public TestService(IRepository<Test> testRepository, IRepository<Question> questionRepository, IRepository<Answer> answerRepository)
        {
            this.testRepository = testRepository;
            this.questionRepository = questionRepository;
            this.answerRepository = answerRepository;
        }
        public async Task AddAsync(Test entity)
        {
            await testRepository.AddAsync(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await testRepository.AddAsync(await testRepository.GetByIdAsync(id));
        }

        public async Task<IEnumerable<Test>> GetAllAsync()
        {
            return await testRepository.All().Include(x => x.Questions).ToListAsync();
        }

        public async Task<Test> GetByIdAsync(int id)
        {
            return await testRepository.GetByIdAsync(id);
        }
    }
}
