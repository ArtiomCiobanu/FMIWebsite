using System;
using System.Threading.Tasks;
using NewsWebsiteAPI.Infrastructure.Results;
using NewsWebsiteAPI.Models.Dto.Accounts;

namespace NewsWebsiteAPI.DataAccess.Services
{
    public interface IAccountService
    {
        public Task<BaseResult> RegisterAsync(RegistrationModel registrationModel);
        public Task<BaseResult> LogInAsync(AuthenticationModel authenticationModel);
        public Task<BaseResult> GetIfExists(Guid id);
    }
}