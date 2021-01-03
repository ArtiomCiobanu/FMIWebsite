using System.Linq;
using FMIWebsiteAPI.Models.Enums;
using Microsoft.AspNetCore.Authorization;

namespace FMIWebsiteAPI.API.Extensions
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