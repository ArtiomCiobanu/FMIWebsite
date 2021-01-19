using System.Threading.Tasks;
using NewsWebsiteAPI.Infrastructure.Results;
using NewsWebsiteAPI.Models.Dto.Accounts;

namespace NewsWebsiteAPI.DataAccess.Services
{
    public interface IAccountService
    {
        public Task<IResult> Register(RegistrationModel registrationModel);
        public Task LogIn();
    }
}