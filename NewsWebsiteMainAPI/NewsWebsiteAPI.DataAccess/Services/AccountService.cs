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

        public IResult Register(RegistrationModel registrationModel)
        {
            if (!AccountRepository.ExistsWithEmail(registrationModel.Email))
                return Result.Fail("The user already exists!");

            AccountRepository.CreateUser(registrationModel);
            return Result.Success("Created");
        }

        public void LogIn()
        {
            throw new System.NotImplementedException();
        }
    }
}