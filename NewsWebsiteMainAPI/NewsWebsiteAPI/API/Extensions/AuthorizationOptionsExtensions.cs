using Microsoft.AspNetCore.Authorization;
using NewsWebsiteAPI.Models.Enums;
using NewsWebsiteAPI.Shared.Consts;

namespace NewsWebsiteAPI.API.Extensions
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