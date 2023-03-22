using TestTaskBLL.Interfaces;
using TestTaskDAL.Entities;
using TestTaskDAL.Interfaces;

namespace TestTaskBLL.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;

        public UserService(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await userRepository.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await userRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(User entity)
        {
            await userRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(User entity)
        {
            await userRepository.DeleteAsync(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await userRepository.DeleteAsync(await userRepository.GetByIdAsync(id));
        }


    }
}
