using TestTask.Domain.Dto;

namespace TestTask.Domain.Interfaces
{
    public interface IAccountService
    {
        /// <summary>
        /// Update Contact infromation for Account.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateContactInformation(ContactInfoUpdateDto entity);

    }
}
