using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsWebsiteAPI.DataAccess.Context;
using NewsWebsiteAPI.Infrastructure.Models.Entities;

namespace NewsWebsiteAPI.DataAccess.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private AccountContext AccountContext { get; }

        public AccountRepository(AccountContext context)
        {
            AccountContext = context;
        }

        public async Task CreateAsync(Account account)
        {
            await AccountContext.Accounts.AddAsync(account);
            await AccountContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Account account)
        {
            AccountContext.Accounts.Update(account);
            await AccountContext.SaveChangesAsync();
        }

        public async Task<Account> GetAsync(Guid id)
            => await AccountContext.Accounts.FindAsync(id);

        public async Task DeleteAsync(Guid id)
        {
            var user = await GetAsync(id);

            AccountContext.Accounts.Remove(user);
            await AccountContext.SaveChangesAsync();
        }

        public Task<Account> GetWithEmailAsync(string email)
            => AccountContext.Accounts.FirstOrDefaultAsync(account => account.Email == email);

        public Task<bool> ExistsWithEmailAsync(string email)
            => AccountContext.Accounts.AnyAsync(account => account.Email == email);

        public Task<bool> ExistsWithIdAsync(Guid id)
            => AccountContext.Accounts.AnyAsync(account => account.Id == id);
    }
}