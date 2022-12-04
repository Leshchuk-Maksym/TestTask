using TestTask.Domain.Dto;

namespace TestTask.Domain.Interfaces
{
    public interface IAccountService
    {
        /// <summary>
        /// Create Account.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task Create(AccountCreateDto entity);

        /// <summary>
        /// Get all Account entitites
        /// </summary>
        /// <returns></returns>
        Task GetAll();

        /// <summary>
        /// Get Account by Account Name.
        /// </summary>
        /// <param name="accountName"></param>
        /// <returns></returns>
        Task GetByName(string accountName);

        /// <summary>
        /// Delete Account by Account Name.
        /// </summary>
        /// <param name="accountName"></param>
        /// <returns></returns>
        Task Delete(string accountName);

        /// <summary>
        /// Update Contact infromation for Account.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateContactInformation(ContactInfoUpdateDto entity);

    }
}
