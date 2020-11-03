using System.Text;
using FMIWebsiteAuthorizationAPI.Models;
using Microsoft.IdentityModel.Tokens;

namespace FMIWebsiteAuthorizationAPI.API
{
    public class JwtConfigurator : IJwtConfigurator
    {
        private JwtConfiguration JwtConfiguration { get; set; }
        public JwtConfiguration GetConfiguration() => JwtConfiguration;

        public JwtConfigurator(JwtConfiguration jwtConfiguration)
        {
            SpecifyConfiguration(jwtConfiguration);
        }

        public TokenValidationParameters ValidationParameters => new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = JwtConfiguration.Issuer,
            ValidateAudience = true,
            ValidAudience = JwtConfiguration.Audience,
            ValidateLifetime = true,
            RequireExpirationTime = true,
            IssuerSigningKey = GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true
        };

        public void SpecifyConfiguration(JwtConfiguration jwtConfiguration)
        {
            JwtConfiguration = jwtConfiguration;
        }

        public SigningCredentials GetSigningCredentials() =>
            new SigningCredentials(GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256Signature);

        private byte[] GetByteKey() => Encoding.UTF8.GetBytes(JwtConfiguration.SecretKey);
        private SymmetricSecurityKey GetSymmetricSecurityKey() => new SymmetricSecurityKey(GetByteKey());
    }
}