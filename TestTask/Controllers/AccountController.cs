using Microsoft.AspNetCore.Mvc;
using TestTask.Domain.Dto;
using TestTask.Domain.Interfaces;

namespace TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContactInformation(ContactInfoUpdateDto entity)
        {
            try
            {
                return Ok(await _accountService.UpdateContactInformation(entity));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
