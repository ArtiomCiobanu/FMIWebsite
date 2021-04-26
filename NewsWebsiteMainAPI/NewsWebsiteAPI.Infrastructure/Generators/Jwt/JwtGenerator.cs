using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using NewsWebsiteAPI.Infrastructure.Configurators;
using NewsWebsiteAPI.Infrastructure.Constants;
using NewsWebsiteAPI.Infrastructure.Enums;

namespace NewsWebsiteAPI.Infrastructure.Generators.Jwt
{
    public class JwtGenerator : IJwtGenerator
    {
        private IJwtConfigurator JwtConfigurator { get; }

        public JwtGenerator(IJwtConfigurator jwtConfigurator)
        {
            JwtConfigurator = jwtConfigurator;
        }

        public string GenerateToken(Guid userId, UserRole userRole)
        {
            var jwtConfiguration = JwtConfigurator.Configuration;
            var signingCredentials = JwtConfigurator.GetSigningCredentials();

            var currentDateTime = DateTime.UtcNow;
            var expirationDateTime = currentDateTime.AddDays(jwtConfiguration.TokenLifetime);
            
            Claim[] claims =
            {
                new(AppClaimTypes.UserId, userId.ToString()),
                new(AppClaimTypes.UserRole, userRole.ToString())
            };

            var jwt = new JwtSecurityToken(
                jwtConfiguration.Issuer,
                jwtConfiguration.Audience,
                claims,
                currentDateTime,
                expirationDateTime,
                signingCredentials);

            var finalToken = new JwtSecurityTokenHandler().WriteToken(jwt);
            return finalToken;
        }
    }
}