using Microsoft.AspNetCore.Mvc;
using TestTaskBLL.Interfaces;
using TestTaskDAL.Entities;

namespace TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService questionService;

        public QuestionController(IQuestionService questionService)
        {
            this.questionService = questionService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await questionService.GetAllAsync());
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await questionService.GetByIdAsync(id));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getByTestId/{id}")]
        public async Task<IActionResult> GetByTestId(int id)
        {
            try
            {
                return Ok(await questionService.GetByTestIdAsync(id));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create(Question entity)
        {
            try
            {
                await questionService.AddAsync(entity);
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
            await questionService.DeleteByIdAsync(id);
        }

        [HttpPost("getRightAnswer/{id}")]
        public async Task<Answer> GetRightAnswerById(int id)
        {
            return await questionService.GetRightAnswerByIdAsync(id);
        }
    }
}
