using TestTaskBLL.Dto;
using TestTaskDAL.Entities;

namespace TestTaskBLL.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task AddAsync(User entity);
        Task DeleteAsync(User entity);
        Task DeleteByIdAsync(int id);

        Task<JwtToken> Register(RegisterDto registerDto);
        Task<JwtToken> Login(LoginDto loginDto);
    }
}
