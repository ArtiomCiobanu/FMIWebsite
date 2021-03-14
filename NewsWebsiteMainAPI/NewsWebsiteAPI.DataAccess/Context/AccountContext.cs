using Microsoft.EntityFrameworkCore;
using NewsWebsiteAPI.Infrastructure.Models.Entities;

namespace NewsWebsiteAPI.DataAccess.Context
{
    public class AccountContext : BaseDbContext<Account>
    {
        //To be removed
        public DbSet<Account> Accounts { get; set; }

        public AccountContext(DbContextOptions options) : base(options)
        {
        }
    }
}