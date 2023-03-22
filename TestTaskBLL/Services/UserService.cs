using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TestTaskBLL.Dto;
using TestTaskBLL.Interfaces;
using TestTaskDAL.Entities;
using TestTaskDAL.Interfaces;

namespace TestTaskBLL.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;
        private readonly IConfiguration configuration;
        public UserService(IRepository<User> userRepository, IConfiguration configuration)
        {
            this.userRepository = userRepository;
            this.configuration = configuration;
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
            var user = await userRepository.All().Where(x => x.Email == entity.Email || x.UserName == entity.UserName).FirstOrDefaultAsync();
            if (user is not null)
            {
                throw new Exception($"User with email {entity.Email} is already exists");
            }

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

        private string CreateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.UserName.ToString()),
                        new Claim(ClaimTypes.Email, user.Email.ToString())
                }),
                Expires = DateTime.Now.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<JwtToken> Register(RegisterDto registerDto)
        {

            var passHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);

            await this.AddAsync(new User { UserName = registerDto.UserName, Email = registerDto.Email, Password = passHash });

            var user = await userRepository.All().Where(x => x.Email == registerDto.Email).FirstOrDefaultAsync();

            var token = CreateToken(user);

            return new JwtToken { Token = token };
        }

        public async Task<JwtToken> Login(LoginDto loginDto)
        {
            var user = await userRepository.All().Where(x => x.UserName == loginDto.UserName).FirstOrDefaultAsync();

            if (user is null)
            {
                throw new Exception("Invalid Username");
            }
            if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
            {
                throw new Exception("Invalid Password");
            }

            var token = CreateToken(user);
            return new JwtToken { Token = token };
        }

    }
}
