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
        private IJwtConfigurator JwtConfigurator { get; set; }
        public IJwtConfigurator GetJwtConfigurator() => JwtConfigurator;

        public JwtManager(IJwtConfigurator jwtConfigurator)
        {
            JwtConfigurator = jwtConfigurator;
        }

        public string GenerateToken(Guid userId, UserRole userRole)
        {
            var jwtConfiguration = JwtConfigurator.GetConfiguration();
            var signingCredentials = JwtConfigurator.GetSigningCredentials();

            var currentDateTime = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                jwtConfiguration.Issuer,
                jwtConfiguration.Audience,
                new[]
                {
                    new Claim("ID", userId.ToString()),
                    new Claim(ClaimTypes.Role, userRole.ToString())
                },
                currentDateTime,
                currentDateTime.AddDays(jwtConfiguration.TokenLifetime),
                signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public string GetUserIdFromToken(string token) => GetUserDataFromToken(token, EndpointConstNames.UserIdClaim);
        public string GetUserRoleFromToken(string token) => GetUserDataFromToken(token, ClaimTypes.Role);

        public string GetUserDataFromToken(string token, string claimType)
        {
            var jwt = (JwtSecurityToken) new JwtSecurityTokenHandler().ReadToken(token);

            var idClaim = jwt.Claims.First(c => c.Type == claimType);

            return idClaim.Value;
        }
    }
}