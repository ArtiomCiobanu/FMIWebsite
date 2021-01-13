using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace NewsWebsiteAPI.Extentions
{
    public static class ClaimsPrincipalExtensions
    {
        public static List<Claim> GetAllClaims(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.Claims.ToList();
        }

        public static Claim GetClaimByType(this ClaimsPrincipal claimsPrincipal, string type)
        {
            return claimsPrincipal.GetAllClaims().FirstOrDefault(c => c.Type == type);
        }
    }
}