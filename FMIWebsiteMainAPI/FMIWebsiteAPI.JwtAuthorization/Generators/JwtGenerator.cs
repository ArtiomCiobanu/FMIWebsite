using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using FMIWebsiteAPI.Models.Accounts;
using FMIWebsiteAPI.Shared.Consts;
using FMIWebsiteAuthorizationAPI.Configurators;

namespace FMIWebsiteAuthorizationAPI.Generators
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

            var jwt = new JwtSecurityToken(
                jwtConfiguration.Issuer,
                jwtConfiguration.Audience,
                new[]
                {
                    new Claim(AppClaimTypes.UserId, userId.ToString()),
                    new Claim(AppClaimTypes.UserRole, userRole.ToString())
                },
                currentDateTime,
                currentDateTime.AddDays(jwtConfiguration.TokenLifetime),
                signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}