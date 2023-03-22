using Microsoft.AspNetCore.Mvc;
using TestTaskBLL.Interfaces;
using TestTaskDAL.Entities;

namespace TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await userService.GetAllAsync());
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await userService.GetByIdAsync(id));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(User entity)
        {
            try
            {
                await userService.AddAsync(entity);
                return Ok($"User with email {entity.Email} has been created");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("deleteById")]
        public async Task DeleteById(int id)
        {
            await userService.DeleteByIdAsync(id);
        }
    }
}
