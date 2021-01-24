using System;
using System.Threading.Tasks;
using NewsWebsiteAPI.DataAccess.Entities;

namespace NewsWebsiteAPI.DataAccess.Repositories
{
    public interface IAccountRepository
    {
        public Task CreateAsync(Account account);
        public Task UpdateAsync(Account account);
        public Task<Account> GetAsync(Guid id);
    }
}