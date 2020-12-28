using System;
using FMIWebsiteAPI.Models.Accounts;
using FMIWebsiteAPI.Models.Enums;

namespace FMIWebsiteAuthorizationAPI.Generators
{
    public interface IJwtGenerator
    {
        string GenerateToken(Guid userId, UserRole userRole);
    }
}