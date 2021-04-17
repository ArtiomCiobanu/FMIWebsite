using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsWebsiteAPI.DataAccess.Context;
using NewsWebsiteAPI.DataAccess.Repositories.Generic;
using NewsWebsiteAPI.Infrastructure.Models.Entities;

namespace NewsWebsiteAPI.DataAccess.Repositories
{
    public class AccountRepository : EfBaseRepository<Account>, IAccountRepository
    {
        private AccountContext AccountContext { get; }

        public AccountRepository(AccountContext context) : base(context)
        {
            AccountContext = context;
        }

        public Task<Account> GetWithEmailAsync(string email)
            => AccountContext.Accounts.FirstOrDefaultAsync(account => account.Email == email);

        public Task<bool> ExistsWithEmailAsync(string email)
            => AccountContext.Accounts.AnyAsync(account => account.Email == email);
    }
}