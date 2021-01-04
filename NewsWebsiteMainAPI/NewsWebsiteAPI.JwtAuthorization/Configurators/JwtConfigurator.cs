using System.Text;
using Microsoft.IdentityModel.Tokens;
using NewsWebsiteAPI.Models.Authorization;

namespace NewsWebsiteAPI.JwtAuthorization.Configurators
{
    public class JwtConfigurator : IJwtConfigurator
    {
        public JwtConfiguration Configuration { get; }

        public JwtConfigurator(JwtConfiguration jwtConfiguration)
        {
            Configuration = jwtConfiguration;
        }

        public TokenValidationParameters ValidationParameters => new()
        {
            ValidateIssuer = true,
            ValidIssuer = Configuration.Issuer,
            ValidateAudience = true,
            ValidAudience = Configuration.Audience,
            ValidateLifetime = true,
            RequireExpirationTime = true,
            IssuerSigningKey = GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true
        };

        public SigningCredentials GetSigningCredentials() =>
            new SigningCredentials(GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256Signature);

        private byte[] GetByteKey() => Encoding.UTF8.GetBytes(Configuration.SecretKey);
        private SymmetricSecurityKey GetSymmetricSecurityKey() => new SymmetricSecurityKey(GetByteKey());
    }
}