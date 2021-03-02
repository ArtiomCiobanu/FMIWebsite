using System;
using System.Threading.Tasks;
using NewsWebsiteAPI.Infrastructure.Models.Dto.Requests.Accounts;
using NewsWebsiteAPI.Infrastructure.Models.Results;

namespace NewsWebsiteAPI.DataAccess.Services
{
    public interface IAccountService
    {
        public Task<BaseResult> RegisterAsync(RegistrationModel registrationModel);
        public Task<BaseResult> LogInAsync(AuthenticationModel authenticationModel);
        public Task<BaseResult> GetIfExists(Guid id);
    }
}