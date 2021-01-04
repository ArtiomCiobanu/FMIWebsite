using Microsoft.IdentityModel.Tokens;
using NewsWebsiteAPI.Models.Authorization;

namespace NewsWebsiteAPI.JwtAuthorization.Configurators
{
    public interface IJwtConfigurator
    {
        JwtConfiguration Configuration { get; }
        TokenValidationParameters ValidationParameters { get; }
        SigningCredentials GetSigningCredentials();
    }
}