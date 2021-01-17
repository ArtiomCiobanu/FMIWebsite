using NewsWebsiteAPI.Infrastructure.Results;
using NewsWebsiteAPI.Models.Dto.Accounts;

namespace NewsWebsiteAPI.DataAccess.Services
{
    public interface IAccountService
    {
        public IResult Register(RegistrationModel registrationModel);
        public void LogIn();
    }
}