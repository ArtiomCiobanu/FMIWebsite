namespace FMIWebsiteAuthorizationAPI.Handlers
{
    public interface IJwtHandler
    {
        string GetUserIdFromToken(string token);
        string GetUserRoleFromToken(string token);
        string GetUserDataFromToken(string token, string claimType);
    }
}