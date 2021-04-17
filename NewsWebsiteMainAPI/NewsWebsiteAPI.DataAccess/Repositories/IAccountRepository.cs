using System.Threading.Tasks;
using NewsWebsiteAPI.DataAccess.Repositories.Generic;
using NewsWebsiteAPI.Infrastructure.Models.Entities;

namespace NewsWebsiteAPI.DataAccess.Repositories
{
    public interface IAccountRepository : IRepository<Account>
    {
        public Task<Account> GetWithEmailAsync(string email);
        public Task<bool> ExistsWithEmailAsync(string email);
    }
}