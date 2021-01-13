using NewsWebsiteAPI.Infrastructure.Repositories;
using NewsWebsiteAPI.Infrastructure.Results;
using NewsWebsiteAPI.Models.Dto.Accounts;

namespace NewsWebsiteAPI.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private IAccountRepository AccountRepository { get; }

        public AccountService(IAccountRepository accountRepository)
        {
            AccountRepository = accountRepository;
        }

        public ResultBase Register(RegistrationModel registrationModel)
        {
            if (AccountRepository.ExistsWithEmail(registrationModel.Email))
            {
                AccountRepository.CreateUser();
                return Result.Success();
            }

            return Result.Fail("The user already exists!");
        }

        public void LogIn()
        {
            throw new System.NotImplementedException();
        }
    }
}