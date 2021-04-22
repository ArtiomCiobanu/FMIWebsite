using Microsoft.EntityFrameworkCore;
using NewsWebsiteAPI.Infrastructure.Models.Entities;

namespace NewsWebsiteAPI.DataAccess.Contexts
{
    public interface IAccountContext
    {
        public DbSet<Account> Accounts { get; set; }
    }
}