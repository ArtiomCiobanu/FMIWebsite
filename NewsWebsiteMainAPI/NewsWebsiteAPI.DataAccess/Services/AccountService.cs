using System;
using System.Threading.Tasks;
using NewsWebsiteAPI.DataAccess.Entities;
using NewsWebsiteAPI.DataAccess.Repositories;
using NewsWebsiteAPI.Infrastructure.Results;
using NewsWebsiteAPI.Models.Dto.Accounts;

namespace NewsWebsiteAPI.DataAccess.Services
{
    public class AccountService : IAccountService
    {
        private IAccountRepository AccountRepository { get; }

        public AccountService(IAccountRepository accountRepository)
        {
            AccountRepository = accountRepository;
        }

        public async Task<IResult> RegisterAsync(RegistrationModel registrationModel)
        {
            /*if (!AccountRepository.ExistsWithEmail(registrationModel.Email))
            {
                return await Task.FromResult(Result.Fail("The user already exists!"));
            }*/
            
            await AccountRepository.CreateAsync(new Account()
            {
                Id = Guid.NewGuid(),
                Email = registrationModel.Email,
                FullName = registrationModel.FullName,
                RoleId = 0 //UserRole.User
            });
            return await Task.FromResult(Result.Success("Created"));
        }

        public Task LogInAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> ExistsAsync(Guid userId)
        {
            var user = await AccountRepository.GetAsync(userId);
            return user != null;
        }
    }
}