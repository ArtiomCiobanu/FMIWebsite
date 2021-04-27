using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsWebsiteAPI.Infrastructure.Models.Entities;

namespace NewsWebsiteAPI.DataAccess.Repositories.Generic
{
    public class EfBaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        private DbContext EntityContext { get; }
        private DbSet<TEntity> EntityDbSet => EntityContext.Set<TEntity>();

        public EfBaseRepository(DbContext entityContext)
        {
            EntityContext = entityContext;
        }

        public async Task CreateAsync(TEntity entity)
        {
            await EntityDbSet.AddAsync(entity);
        }

        public Task UpdateAsync(TEntity entity)
        {
            return Task.FromResult(EntityDbSet.Update(entity));
        }

        public async Task<TEntity> GetAsync(Guid id)
            => await EntityDbSet.FindAsync(id);

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetAsync(id);

            EntityDbSet.Remove(entity);
            await EntityContext.SaveChangesAsync();
        }

        public Task SaveChangesAsync()
            => EntityContext.SaveChangesAsync();

        public Task<bool> ExistsWithIdAsync(Guid id)
            => EntityDbSet.AnyAsync(entity => entity.Id == id);
    }
}