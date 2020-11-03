using FMIWebsiteAuthorizationAPI.Models;
using Microsoft.IdentityModel.Tokens;

namespace FMIWebsiteAuthorizationAPI.API
{
    public interface IJwtConfigurator
    {
        JwtConfiguration GetConfiguration();
        TokenValidationParameters ValidationParameters { get; }
        void SpecifyConfiguration(JwtConfiguration jwtConfiguration);
        SigningCredentials GetSigningCredentials();
    }
}