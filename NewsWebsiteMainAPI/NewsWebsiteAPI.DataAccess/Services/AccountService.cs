using System;
using System.Threading.Tasks;
using NewsWebsiteAPI.DataAccess.Repositories;
using NewsWebsiteAPI.Infrastructure.Generators.Hashing;
using NewsWebsiteAPI.Infrastructure.Generators.Jwt;
using NewsWebsiteAPI.Infrastructure.Models.Dto.Requests.Accounts;
using NewsWebsiteAPI.Infrastructure.Models.Dto.Responses.Accounts;
using NewsWebsiteAPI.Infrastructure.Models.Dto.Responses.Generic;
using NewsWebsiteAPI.Infrastructure.Models.Entities;

namespace NewsWebsiteAPI.DataAccess.Services
{
    public class AccountService : IAccountService
    {
        private IAccountRepository AccountRepository { get; }
        private IHashGenerator HashGenerator { get; }
        private IJwtGenerator JwtGenerator { get; }

        public AccountService(
            IAccountRepository accountRepository,
            IHashGenerator hashGenerator,
            IJwtGenerator jwtGenerator)
        {
            AccountRepository = accountRepository;
            HashGenerator = hashGenerator;
            JwtGenerator = jwtGenerator;
        }

        public async Task<BaseResponse> RegisterAsync(RegistrationRequest registrationRequest)
        {
            if (await AccountRepository.ExistsWithEmailAsync(registrationRequest.Email))
            {
                return BaseResponse.Unauthorized("There is already a user with this email!");
            }

            var passwordHash = await HashGenerator.GenerateSaltedHash(registrationRequest.Password);

            var account = new Account
            {
                Id = Guid.NewGuid(),
                Email = registrationRequest.Email,
                FullName = registrationRequest.FullName,
                RoleId = 0, //UserRole.User
                PasswordHash = passwordHash
            };

            await AccountRepository.CreateAsync(account);

            var token = JwtGenerator.GenerateToken(account.Id);
            return TokenResponse.Success(token);
        }

        public async Task<BaseResponse> LogInAsync(AuthenticationRequest authenticationRequest)
        {
            var account = await AccountRepository.GetWithEmailAsync(authenticationRequest.Email);

            if (account != null)
            {
                var passwordHash = await HashGenerator.GenerateSaltedHash(authenticationRequest.Password);

                if (account.PasswordHash == passwordHash)
                {
                    var token = JwtGenerator.GenerateToken(account.Id);

                    return TokenResponse.Success(token);
                }
            }

            return BaseResponse.Unauthorized("Email or password is incorrect.");
        }

        public async Task<BaseResponse> GetIfExists(Guid id)
        {
            if (await AccountRepository.ExistsWithIdAsync(id))
            {
                var account = await AccountRepository.GetAsync(id);

                return AccountResponse.Success(account.FullName);
            }

            return BaseResponse.Unauthorized("User does not exist.");
        }
    }
}