using FMIWebsiteAPI.Models.Authorization;
using Microsoft.IdentityModel.Tokens;

namespace FMIWebsiteAuthorizationAPI.API
{
    public interface IJwtConfigurator
    {
        JwtConfiguration Configuration { get; }
        TokenValidationParameters ValidationParameters { get; }
        void SpecifyConfiguration(JwtConfiguration jwtConfiguration);
        SigningCredentials GetSigningCredentials();
    }
}