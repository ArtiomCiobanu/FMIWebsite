using System;
using FMIWebsiteAPI.Models.Accounts;

namespace FMIWebsiteAuthorizationAPI.API
{
    public interface IJwtManager
    {
        IJwtConfigurator GetJwtConfigurator();
        string GenerateToken(Guid userId, UserRole userRole);
        string GetUserIdFromToken(string token);
        string GetUserRoleFromToken(string token);
        string GetUserDataFromToken(string token, string claimType);
    }
}