using System;
using FMIWebsiteAPI.Models.Accounts;

namespace FMIWebsiteAuthorizationAPI.Generators
{
    public interface IJwtGenerator
    {
        string GenerateToken(Guid userId, UserRole userRole);
    }
}