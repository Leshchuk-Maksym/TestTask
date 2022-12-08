using TestTask.DataAccess.Entities;
using TestTask.DataAccess.Interfaces;
using TestTask.Domain.Dto;
using TestTask.Domain.Interfaces;

namespace TestTask.Domain.Services
{
    public class AccountService : IAccountService
    {
        public IRepository<Account> _accountsRepository;
        public IRepository<Contact> _contactsRepository;
        public IRepository<Incident> _incidentsRepository;

        public AccountService(IRepository<Account> accountsRepository, IRepository<Contact> contactsRepository, IRepository<Incident> incidentsRepository)
        {
            _accountsRepository = accountsRepository;
            _contactsRepository = contactsRepository;
            _incidentsRepository = incidentsRepository;
        }

        // <summary>
        /// Create Account.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Create(AccountCreateDto entity)
        {
            var accountEntity = await _accountsRepository.GetByKeyAsync(entity.AccountName);

            if (accountEntity != null)
            {
                throw new ArgumentException(nameof(accountEntity));
            }

            accountEntity = await _accountsRepository.AddAsync(entity.AccountName);

            var contactEntity = await _contactsRepository.GetByKeyAsync(entity.Email);

            if (contactEntity != null)
            {
                contactEntity.FirstName = entity.FirstName;
                contactEntity.LastName = entity.LastName;
                await _contactsRepository.UpdateAsync(contactEntity);

                if (!accountEntity.Contacts.Any(x => x.Email == contactEntity.Email))
                {
                    accountEntity.Contacts.Add(contactEntity);
                    await _accountsRepository.UpdateAsync(accountEntity);
                }
            }
            else
            {
                await _contactsRepository.AddAsync(new Contact
                {
                    Email = entity.Email,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName
                });
            }
        }

        /// <summary>
        /// Delete Account by Account Name.
        /// </summary>
        /// <param name="accountName"></param>
        /// <returns></returns>
        public async Task Delete(string accountName)
        {
            await _accountsRepository.RemoveAsync(accountName);
        }

        /// <summary>
        /// Get all Account entitites
        /// </summary>
        /// <returns></returns>
        public async Task GetAll()
        {
            return await _accountsRepository.GetAllAsync();
        }

        /// <summary>
        /// Get Account by Account Name.
        /// </summary>
        /// <param name="accountName"></param>
        /// <returns></returns>
        public async Task GetByName(string accountName)
        {
            return await _accountsRepository.GetByKeyAsync(accountName);
        }

        /// <summary>
        /// Update Contact infromation for Account.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task UpdateContactInformation(ContactInfoUpdateDto entity)
        {
            var accountEntity = await _accountsRepository.GetByKeyAsync(entity.AccountName);

            if (accountEntity == null)
            {
                throw new ArgumentNullException(nameof(accountEntity));
            }

            var contactEntity = await _contactsRepository.GetByKeyAsync(entity.Email);

            if (contactEntity != null)
            {
                contactEntity.FirstName = entity.FirstName;
                contactEntity.LastName = entity.LastName;
                await _contactsRepository.UpdateAsync(contactEntity);

                if (!accountEntity.Contacts.Any(x => x.Email == contactEntity.Email))
                {
                    accountEntity.Contacts.Add(contactEntity);
                    await _accountsRepository.UpdateAsync(accountEntity);
                }
            }
            else
            {
                await _contactsRepository.AddAsync(new Contact
                {
                    Email = entity.Email,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName
                });
            }

            await _incidentsRepository.AddAsync(new Incident
            {
                Accounts = new List<Account> { accountEntity },
                Description = entity.IncidentDesciption
            });
        }
    }
}
