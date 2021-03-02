using System;
using System.Threading.Tasks;
using NewsWebsiteAPI.Infrastructure.Models.Dto.Requests.Accounts;
using NewsWebsiteAPI.Infrastructure.Models.Dto.Responses.Generic;

namespace NewsWebsiteAPI.DataAccess.Services
{
    public interface IAccountService
    {
        public Task<BaseResponse> RegisterAsync(RegistrationRequest registrationRequest);
        public Task<BaseResponse> LogInAsync(AuthenticationRequest authenticationRequest);
        public Task<BaseResponse> GetIfExists(Guid id);
    }
}