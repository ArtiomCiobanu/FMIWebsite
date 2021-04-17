using Microsoft.EntityFrameworkCore;
using NewsWebsiteAPI.Infrastructure.Models.Entities;

namespace NewsWebsiteAPI.DataAccess.Context
{
    public interface IAccountContext
    {
        public DbSet<Account> Accounts { get; set; }
    }
}