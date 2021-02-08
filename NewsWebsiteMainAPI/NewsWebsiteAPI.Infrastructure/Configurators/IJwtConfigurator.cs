using Microsoft.IdentityModel.Tokens;
using NewsWebsiteAPI.Models.Configuration;

namespace NewsWebsiteAPI.Infrastructure.Configurators
{
    public interface IJwtConfigurator
    {
        JwtConfiguration Configuration { get; }
        TokenValidationParameters ValidationParameters { get; }
        SigningCredentials GetSigningCredentials();
    }
}