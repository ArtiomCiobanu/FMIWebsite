using NewsWebsiteAPI.Infrastructure.Results;
using NewsWebsiteAPI.Models.Dto.Accounts;

namespace NewsWebsiteAPI.Infrastructure.Services
{
    public interface IAccountService
    {
        public ResultBase Register(RegistrationModel registrationModel);
        public void LogIn();
    }
}