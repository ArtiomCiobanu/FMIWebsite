using System;
using System.Threading.Tasks;
using NewsWebsiteAPI.Infrastructure.Results;
using NewsWebsiteAPI.Models.Dto.Accounts;

namespace NewsWebsiteAPI.DataAccess.Services
{
    public interface IAccountService
    {
        public Task<IResult> RegisterAsync(RegistrationModel registrationModel);
        public Task LogInAsync();
        public Task<bool> ExistsAsync(Guid userId);
    }
}