using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using FMIWebsiteAPI.Models.Accounts;
using FMIWebsiteAPI.Shared;

namespace FMIWebsiteAuthorizationAPI.API
{
    public class JwtManager : IJwtManager
    {
        private IJwtConfigurator JwtConfigurator { get; }

        public JwtManager(IJwtConfigurator jwtConfigurator)
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

        public string GetUserIdFromToken(string token) => GetUserDataFromToken(token, AppClaimTypes.UserId);
        public string GetUserRoleFromToken(string token) => GetUserDataFromToken(token, AppClaimTypes.UserRole);

        public string GetUserDataFromToken(string token, string claimType)
        {
            var jwt = (JwtSecurityToken) new JwtSecurityTokenHandler().ReadToken(token);

            var result = jwt.Claims.First(c => c.Type == claimType);
            return result.Value;
        }
    }
}