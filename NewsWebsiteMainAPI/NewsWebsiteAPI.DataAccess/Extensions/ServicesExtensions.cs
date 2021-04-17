using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace NewsWebsiteAPI.DataAccess.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddDbContextForConnectionString<TDbContext>(this IServiceCollection services, string connectionString)
        where TDbContext : DbContext
        {
            services.AddDbContext<TDbContext>(options => { options.UseSqlServer(connectionString); });
        }
    }
}