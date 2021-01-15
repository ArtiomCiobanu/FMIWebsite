using System.IdentityModel.Tokens.Jwt;
using NewsWebsiteAPI.Shared.Consts;
using NewsWebsiteAPI.Shared.Extensions;

namespace NewsWebsiteAPI.Infrastructure.Handlers
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