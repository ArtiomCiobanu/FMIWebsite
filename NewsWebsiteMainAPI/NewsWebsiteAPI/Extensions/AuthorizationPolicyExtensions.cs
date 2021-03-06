﻿using System.Linq;
using Microsoft.AspNetCore.Authorization;
using NewsWebsiteAPI.Infrastructure.Enums;

namespace NewsWebsiteAPI.Extensions
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