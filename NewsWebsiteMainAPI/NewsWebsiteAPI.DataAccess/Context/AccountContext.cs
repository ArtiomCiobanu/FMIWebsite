using Microsoft.EntityFrameworkCore;
using NewsWebsiteAPI.DataAccess.Context.Generic;
using NewsWebsiteAPI.Infrastructure.Models.Entities;

namespace NewsWebsiteAPI.DataAccess.Context
{
    public class AccountContext : BaseContext, IAccountContext
    {
        public DbSet<Account> Accounts { get; set; }

        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {
        }
    }
}