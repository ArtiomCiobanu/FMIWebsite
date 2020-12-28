using FMIWebsiteAPI.Models.Accounts;
using Microsoft.EntityFrameworkCore;

namespace FMIWebsiteAPI.Database
{
    public class MainContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}