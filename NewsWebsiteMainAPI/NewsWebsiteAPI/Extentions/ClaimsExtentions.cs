using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace NewsWebsiteAPI.Extentions
{
    public static class ClaimsExtentions
    {
        public static Claim GetClaim(this ClaimsPrincipal principal, string claimType)
        {
            return principal.Claims.GetClaim(claimType);
        }

        public static Claim GetClaim(this IEnumerable<Claim> claims, string claimType)
        {
            return claims.First(c => c.Type == claimType);
        }
    }
}