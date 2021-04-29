namespace NewsWebsiteAPI.Infrastructure.Handlers
{
    public interface IJwtReader
    {
        string GetUserIdFromToken(string token);
        string GetUserRoleFromToken(string token);
        string GetUserDataFromToken(string token, string claimType);
    }
}