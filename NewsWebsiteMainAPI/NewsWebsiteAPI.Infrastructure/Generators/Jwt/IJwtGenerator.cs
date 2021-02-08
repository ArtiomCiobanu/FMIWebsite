using System;
using NewsWebsiteAPI.Infrastructure.Enums;

namespace NewsWebsiteAPI.Infrastructure.Generators.Jwt
{
    public interface IJwtGenerator
    {
        string GenerateToken(Guid userId, UserRole userRole);
    }
}