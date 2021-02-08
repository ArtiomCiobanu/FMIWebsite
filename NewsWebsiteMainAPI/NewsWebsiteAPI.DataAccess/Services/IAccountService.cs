using System;
using System.Threading.Tasks;
using NewsWebsiteAPI.Infrastructure.Results;
using NewsWebsiteAPI.Models.Dto.Accounts;

namespace NewsWebsiteAPI.DataAccess.Services
{
    public interface IAccountService
    {
        public Task<Result> RegisterAsync(RegistrationModel registrationModel);
        public Task<Result> LogInAsync(AuthenticationModel authenticationModel);
        public Task<bool> GetExistsWithIdAsync(Guid userId);
        public Task<bool> ExistsWithEmailAsync(string email);
    }
}