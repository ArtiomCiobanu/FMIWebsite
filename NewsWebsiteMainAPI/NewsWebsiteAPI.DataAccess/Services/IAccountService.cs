using System;
using System.Threading.Tasks;
using NewsWebsiteAPI.Infrastructure.Models.Dto.Requests.Accounts;
using NewsWebsiteAPI.Infrastructure.Models.Dto.Responses.Accounts;
using NewsWebsiteAPI.Infrastructure.Models.Dto.Responses.Generic;

namespace NewsWebsiteAPI.DataAccess.Services
{
    public interface IAccountService
    {
        public Task<TokenResponse> RegisterAsync(RegistrationRequest registrationRequest);
        public Task<TokenResponse> LogInAsync(AuthenticationRequest authenticationRequest);
        public Task<AccountResponse> GetIfExists(Guid id);
    }
}