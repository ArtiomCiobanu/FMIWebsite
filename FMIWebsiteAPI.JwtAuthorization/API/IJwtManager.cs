namespace FMIWebsiteAuthorizationAPI.API
{
    public interface IJwtManager
    {
        IJwtConfigurator GetJwtConfigurator();
        string GenerateToken(string userId, string userRole);
        string GetUserIdFromToken(string token);
        string GetUserRoleFromToken(string token);
        string GetUserDataFromToken(string token, string claimType);
    }
}