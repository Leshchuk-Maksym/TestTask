using Microsoft.AspNetCore.Mvc;
using TestTaskBLL.Interfaces;
using TestTaskDAL.Entities;

namespace TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService testService;

        public TestController(ITestService testService)
        {
            this.testService = testService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await testService.GetAllAsync());
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await testService.GetByIdAsync(id));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(Test entity)
        {
            try
            {
                await testService.AddAsync(entity);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("deleteById")]
        public async Task DeleteById(int id)
        {
            await testService.DeleteByIdAsync(id);
        }
    }
}
