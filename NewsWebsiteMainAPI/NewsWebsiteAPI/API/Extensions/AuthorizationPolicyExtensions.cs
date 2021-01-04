using System.Linq;
using Microsoft.AspNetCore.Authorization;
using NewsWebsiteAPI.Models.Enums;

namespace NewsWebsiteAPI.API.Extensions
{
    public static class AuthorizationPolicyExtensions
    {
        public static void RequireUserRole(
            this AuthorizationPolicyBuilder policyBuilder,
            params UserRole[] userRoles)
        {
            var roles = userRoles.Select(role => role.ToString());
            policyBuilder.RequireRole(roles);
        }
    }
}