using Microsoft.AspNetCore.Identity;
using NewsWebsiteAPI.DataAccess.Entities;
using NewsWebsiteAPI.Models.Dto.Accounts;

namespace NewsWebsiteAPI.DataAccess.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private UserManager<Account> UserManager { get; }

        public AccountRepository(UserManager<Account> userManager)
        {
            UserManager = userManager;
        }

        public bool ExistsWithEmail(string email)
        {
            return true;
        }

        public void CreateUser(RegistrationModel registrationModel)
        {
        }
    }
}