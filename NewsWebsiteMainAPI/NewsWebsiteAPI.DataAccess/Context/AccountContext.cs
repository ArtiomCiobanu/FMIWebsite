using Microsoft.EntityFrameworkCore;
using NewsWebsiteAPI.Infrastructure.Models.Entities;

namespace NewsWebsiteAPI.DataAccess.Context
{
    public class AccountContext : DbContext
    {
        //To be removed
        public DbSet<Account> Accounts { get; set; }

        public AccountContext(DbContextOptions options) : base(options)
        {
        }
    }
}