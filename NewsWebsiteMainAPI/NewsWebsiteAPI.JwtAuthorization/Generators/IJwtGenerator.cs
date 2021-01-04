using System;
using NewsWebsiteAPI.Models.Enums;

namespace NewsWebsiteAPI.JwtAuthorization.Generators
{
    public interface IJwtGenerator
    {
        string GenerateToken(Guid userId, UserRole userRole);
    }
}