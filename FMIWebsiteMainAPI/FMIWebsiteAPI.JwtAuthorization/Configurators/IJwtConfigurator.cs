using FMIWebsiteAPI.Models.Authorization;
using Microsoft.IdentityModel.Tokens;

namespace FMIWebsiteAuthorizationAPI.Configurators
{
    public interface IJwtConfigurator
    {
        JwtConfiguration Configuration { get; }
        TokenValidationParameters ValidationParameters { get; }
        SigningCredentials GetSigningCredentials();
    }
}