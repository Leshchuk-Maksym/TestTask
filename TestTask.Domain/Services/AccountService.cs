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

        public async Task<string> UpdateContactInformation(ContactInfoUpdateDto entity)
        {
            await _contactsRepository.AddAsync(new Contact
            {
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName = entity.LastName
            });

            var contactEntity = await _contactsRepository.GetByKeyAsync(entity.Email);

            var accountEntity = await _accountsRepository.GetByKeyAsync(entity.AccountName);

            if (accountEntity == null)
            {
                await _accountsRepository.AddAsync(new Account
                {
                    Name = entity.AccountName,
                    Contacts = new List<Contact> { contactEntity }
                });
                accountEntity = await _accountsRepository.GetByKeyAsync(entity.AccountName);
            }
            else
            {
                accountEntity.Contacts.Add(contactEntity);

                await _accountsRepository.UpdateAsync(accountEntity);
            }


            await _incidentsRepository.AddAsync(new Incident
            {
                Accounts = new List<Account> { accountEntity },
                Description = entity.IncidentDesciption
            });

            //var incidentEntity = _incidentsRepository.FindAsync();


            return entity.IncidentDesciption;

        }
    }
}
