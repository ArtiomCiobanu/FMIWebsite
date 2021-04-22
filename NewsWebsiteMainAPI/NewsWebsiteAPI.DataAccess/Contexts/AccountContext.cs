using Microsoft.EntityFrameworkCore;
using NewsWebsiteAPI.Infrastructure.Models.Entities;

namespace NewsWebsiteAPI.DataAccess.Context
{
    public class AccountContext : DbContext, IAccountContext
    {
        public DbSet<Account> Accounts { get; set; }

        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {
        }
    }
}