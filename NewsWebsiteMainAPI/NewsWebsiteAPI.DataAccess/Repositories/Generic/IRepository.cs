using System;
using System.Threading.Tasks;

namespace NewsWebsiteAPI.DataAccess.Repositories.Generic
{
    public interface IRepository<T>
    {
        public Task CreateAsync(T account);
        public Task UpdateAsync(T account);
        public Task<T> GetAsync(Guid id);
        public Task DeleteAsync(Guid id);

        public Task<bool> ExistsWithIdAsync(Guid id);
    }
}