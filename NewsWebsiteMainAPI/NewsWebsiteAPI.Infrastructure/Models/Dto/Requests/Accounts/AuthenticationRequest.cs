namespace NewsWebsiteAPI.Infrastructure.Models.Dto.Requests.Accounts
{
    public class AuthenticationRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}