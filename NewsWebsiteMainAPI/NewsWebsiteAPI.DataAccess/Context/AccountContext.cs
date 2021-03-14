using Microsoft.EntityFrameworkCore;
using NewsWebsiteAPI.Infrastructure.Models.Entities;

namespace NewsWebsiteAPI.DataAccess.Context
{
    public class AccountContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public AccountContext(DbContextOptions options) : base(options)
        {
        }
    }
}