using TestTask.Domain.Dto;

namespace TestTask.Domain.Interfaces
{
    public interface IAccountService
    {
        Task<string> UpdateContactInformation(ContactInfoUpdateDto entity);

    }
}
