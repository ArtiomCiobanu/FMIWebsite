using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using FMIWebsiteAPI.Models.Accounts;
using FMIWebsiteAPI.Shared.Consts;
using FMIWebsiteAPI.Shared.Extentions;
using FMIWebsiteAuthorizationAPI.Configurators;

namespace FMIWebsiteAuthorizationAPI.Handlers
{
    public class JwtHandler : IJwtHandler
    {
        public string GetUserIdFromToken(string token) => GetUserDataFromToken(token, AppClaimTypes.UserId);
        public string GetUserRoleFromToken(string token) => GetUserDataFromToken(token, AppClaimTypes.UserRole);

        public string GetUserDataFromToken(string token, string claimType)
        {
            var jwt = (JwtSecurityToken) new JwtSecurityTokenHandler().ReadToken(token);

            var result = jwt.Claims.GetClaim(claimType);
            return result.Value;
        }
    }
}