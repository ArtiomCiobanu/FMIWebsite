using Microsoft.EntityFrameworkCore;
using NewsWebsiteAPI.Infrastructure.Models.Entities;

namespace NewsWebsiteAPI.DataAccess.Context
{
    public class BaseDbContext<TEntity> : DbContext
        where TEntity : class
    {
        public DbSet<TEntity> Data { get; set; }

        public BaseDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}