
using System.Security.Claims;

namespace NewsWebsiteAPI.Infrastructure.Constants
{
    public static class AppClaimTypes
    {
        public const string UserId = "UserId";

        public const string UserRole = ClaimTypes.Role;
    }
}