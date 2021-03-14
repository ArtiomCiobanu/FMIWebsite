using System;
using System.Threading.Tasks;

namespace NewsWebsiteAPI.DataAccess.Repositories.Generic
{
    public class EfBaseRepository<TEntity, TContext> : IRepository<TEntity>
    {
        public Task CreateAsync(TEntity account)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TEntity account)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsWithIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}