using Microsoft.EntityFrameworkCore;
using TestTaskBLL.Interfaces;
using TestTaskDAL.Entities;
using TestTaskDAL.Interfaces;

namespace TestTaskBLL.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IRepository<Question> questionRepository;
        private readonly IRepository<Answer> answerRepository;

        public QuestionService(IRepository<Question> questionRepository, IRepository<Answer> answerRepository)
        {
            this.questionRepository = questionRepository;
            this.answerRepository = answerRepository;
        }
        public async Task AddAsync(Question entity)
        {
            await questionRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(Question entity)
        {
            await questionRepository.DeleteAsync(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await questionRepository.DeleteAsync(await questionRepository.GetByIdAsync(id));
        }

        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            return await questionRepository.GetAllAsync();
        }

        public async Task<Question> GetByIdAsync(int id)
        {
            return await questionRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Question>> GetByTestIdAsync(int id)
        {
            return await questionRepository.All().Include(x => x.Answers).Where(x => x.TestId == id).ToListAsync();
        }

        public async Task<double> CheckAnswers(List<int> answersIds)
        {

            var resultQuery = answerRepository.All().Where(x => answersIds.Any(y => y == x.Id));
            resultQuery = resultQuery.Where(x => x.IsRight);
            var result = Math.Round((double)await resultQuery.CountAsync() / (double)answersIds.Count, 2);
            return result;
        }
    }
}
