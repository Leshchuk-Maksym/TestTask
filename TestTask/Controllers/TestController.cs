using Microsoft.AspNetCore.Mvc;
using TestTaskBLL.Dto;
using TestTaskBLL.Interfaces;
using TestTaskDAL.Entities;

namespace TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService testService;
        private readonly IQuestionService questionService;

        public TestController(ITestService testService, IQuestionService questionService)
        {
            this.testService = testService;
            this.questionService = questionService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await testService.GetAllAsync());
        }

        [HttpGet("getById/{id}")]
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

        [HttpGet("getByUserId/{id}")]
        public async Task<IActionResult> GetByUserId(int id)
        {
            try
            {
                return Ok(await testService.GetByUserIdAsync(id));
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

        [HttpDelete("deleteById/{id}")]
        public async Task DeleteById(int id)
        {
            await testService.DeleteByIdAsync(id);
        }

        [HttpPost("checkAnswers")]
        public async Task<IActionResult> CheckAnswers([FromBody] AnswersDto answers)
        {
            var result = await questionService.CheckAnswers(answers.AnswersIds);
            await testService.UpdateBestScoreAsync(result, answers.TestId);

            return Ok(result);
        }
    }
}
