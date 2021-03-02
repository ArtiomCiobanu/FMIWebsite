using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsWebsiteAPI.DataAccess.Context;
using NewsWebsiteAPI.Infrastructure.Models.Entities;

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
            => await _accountContext.Accounts.FindAsync(id);

        public async Task DeleteAsync(Guid id)
        {
            var user = await GetAsync(id);

            _accountContext.Accounts.Remove(user);
            await _accountContext.SaveChangesAsync();
        }

        public Task<Account> GetWithEmailAsync(string email)
            => _accountContext.Accounts.FirstOrDefaultAsync(account => account.Email == email);

        public Task<bool> ExistsWithEmailAsync(string email)
            => _accountContext.Accounts.AnyAsync(account => account.Email == email);

        public Task<bool> ExistsWithIdAsync(Guid id)
            => _accountContext.Accounts.AnyAsync(account => account.Id == id);
    }
}