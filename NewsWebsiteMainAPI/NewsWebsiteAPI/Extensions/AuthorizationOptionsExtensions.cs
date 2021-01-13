using Microsoft.AspNetCore.Authorization;
using NewsWebsiteAPI.Consts;
using NewsWebsiteAPI.Models.Enums;

namespace NewsWebsiteAPI.Extensions
{
    public static class AuthorizationOptionsExtensions
    {
        public static void AddRequireAdministratorRolePolicy(this AuthorizationOptions options)
        {
            options.AddPolicy(
                PolicyNames.RequireAdministratorRole,
                policy => policy.RequireUserRole(UserRole.Admin));
        }
    }
}