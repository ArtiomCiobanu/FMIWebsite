using Microsoft.EntityFrameworkCore;
using NewsWebsiteAPI.DataAccess.Entities;

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