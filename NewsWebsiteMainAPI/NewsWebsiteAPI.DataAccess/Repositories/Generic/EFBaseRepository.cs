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
        private DbSet<TEntity> EntityDbSet { get; }

        public EfBaseRepository(DbContext entityContext)
        {
            EntityContext = entityContext;
            EntityDbSet = EntityContext.Set<TEntity>();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await EntityDbSet.AddAsync(entity);
            await EntityContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            EntityDbSet.Update(entity);
            await EntityContext.SaveChangesAsync();
        }

        public async Task<TEntity> GetAsync(Guid id)
            => await EntityDbSet.FindAsync(id);

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetAsync(id);

            EntityDbSet.Remove(entity);
            await EntityContext.SaveChangesAsync();
        }

        public Task<bool> ExistsWithIdAsync(Guid id)
            => EntityDbSet.AnyAsync(entity => entity.Id == id);
    }
}