using System.Threading.Tasks;
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

        public async Task<IResult> Register(RegistrationModel registrationModel)
        {
            if (!AccountRepository.ExistsWithEmail(registrationModel.Email))
            {
                return await Task.FromResult(Result.Fail("The user already exists!"));
            }

            AccountRepository.CreateUser(registrationModel);
            return await Task.FromResult(Result.Success("Created"));
        }

        public Task LogIn()
        {
            throw new System.NotImplementedException();
        }
    }
}