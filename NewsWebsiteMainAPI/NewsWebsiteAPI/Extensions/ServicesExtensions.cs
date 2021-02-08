using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewsWebsiteAPI.Consts;
using NewsWebsiteAPI.DataAccess.Repositories;
using NewsWebsiteAPI.DataAccess.Services;
using NewsWebsiteAPI.Infrastructure.Configurators;
using NewsWebsiteAPI.Infrastructure.Generators;
using NewsWebsiteAPI.Infrastructure.Generators.Jwt;
using NewsWebsiteAPI.Infrastructure.Handlers;
using NewsWebsiteAPI.Models.Authorization;

namespace NewsWebsiteAPI.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
        }

        public static void AddJwt(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IJwtConfigurator, JwtConfigurator>(_ =>
            {
                var jwtConfiguration = configuration
                    .GetSection(SettingsSections.JwtConfiguration).Get<JwtConfiguration>();

                return new JwtConfigurator(jwtConfiguration);
            });

            services.AddSingleton<IJwtGenerator, JwtGenerator>();
            services.AddSingleton<IJwtHandler, JwtHandler>();
        }
    }
}