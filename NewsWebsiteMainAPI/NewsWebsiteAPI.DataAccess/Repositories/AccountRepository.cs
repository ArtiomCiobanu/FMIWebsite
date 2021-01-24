using System;
using System.Threading.Tasks;
using NewsWebsiteAPI.DataAccess.Context;
using NewsWebsiteAPI.DataAccess.Entities;

namespace NewsWebsiteAPI.DataAccess.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AccountContext _accountContext;

        public AccountRepository(AccountContext context)
        {
            _accountContext = context;
        }

        public async Task CreateAsync(Account account)
        {
            await _accountContext.Accounts.AddAsync(account);
            await _accountContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Account account)
        {
            _accountContext.Accounts.Update(account);
            await _accountContext.SaveChangesAsync();
        }

        public async Task<Account> GetAsync(Guid id)
        {
            return await _accountContext.Accounts.FindAsync(id);
        }
    }
}