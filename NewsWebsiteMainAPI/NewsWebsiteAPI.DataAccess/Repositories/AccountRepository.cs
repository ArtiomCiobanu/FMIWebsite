using System;
using NewsWebsiteAPI.DataAccess.Context;
using NewsWebsiteAPI.DataAccess.Entities;
using NewsWebsiteAPI.Infrastructure.Enums;
using NewsWebsiteAPI.Models.Dto.Accounts;

namespace NewsWebsiteAPI.DataAccess.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        /*private UserManager<Account> UserManager { get; }

        public AccountRepository(UserManager<Account> userManager)
        {
            UserManager = userManager;
        }*/

        private readonly AccountContext _accountContext;

        public AccountRepository(AccountContext context)
        {
            _accountContext = context;
        }

        public bool ExistsWithEmail(string email)
        {
            return true;
        }

        public void CreateUser(RegistrationModel registrationModel)
        {
            _accountContext.Add(new Account()
            {
                Id = Guid.NewGuid(),
                Email = registrationModel.Email,
                FullName = registrationModel.FullName,
                RoleId = 0 //UserRole.User
            });
            _accountContext.SaveChanges();
        }
    }
}