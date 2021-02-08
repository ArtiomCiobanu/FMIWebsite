using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NewsWebsiteAPI.DataAccess.Context;

namespace NewsWebsiteAPI.DataAccess.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddAccountDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AccountContext>(options => { options.UseSqlServer(connectionString); });
        }
    }
}