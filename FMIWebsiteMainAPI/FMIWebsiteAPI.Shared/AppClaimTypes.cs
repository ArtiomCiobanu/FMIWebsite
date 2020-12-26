
using System.Security.Claims;

namespace FMIWebsiteAPI.Shared
{
    public static class AppClaimTypes
    {
        public const string UserId = "UserId";
        public const string AuthorizationHeader = "Authorization";

        public const string UserRole = ClaimTypes.Role;
    }
}