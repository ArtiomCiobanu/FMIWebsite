using System;
using System.Linq;
using System.Threading.Tasks;
using NewsWebsiteAPI.DataAccess.Repositories;
using NewsWebsiteAPI.Infrastructure.Enums;
using NewsWebsiteAPI.Infrastructure.Generators.Hashing;
using NewsWebsiteAPI.Infrastructure.Generators.Jwt;
using NewsWebsiteAPI.Infrastructure.Models.Dto.Requests.Accounts;
using NewsWebsiteAPI.Infrastructure.Models.Dto.Responses.Accounts;
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

        public async Task<TokenResponse> RegisterAsync(RegistrationRequest registrationRequest)
        {
            if (await AccountRepository.ExistsWithEmailAsync(registrationRequest.Email))
            {
                return TokenResponse.Unauthorized();
            }

            var passwordHash = await HashGenerator.GenerateSaltedHash(registrationRequest.Password);

            var account = new Account
            {
                Id = Guid.NewGuid(),
                Email = registrationRequest.Email,
                FullName = registrationRequest.FullName,
                RoleId = (int) UserRole.User,
                PasswordHash = passwordHash
            };

            await AccountRepository.CreateAsync(account);
            await AccountRepository.SaveChangesAsync();

            var token = JwtGenerator.GenerateToken(account.Id);
            return TokenResponse.Success(token);
        }

        public async Task<TokenResponse> LogInAsync(AuthenticationRequest authenticationRequest)
        {
            var account = await AccountRepository.GetWithEmailAsync(authenticationRequest.Email);

            if (account != null)
            {
                var passwordHash = await HashGenerator.GenerateSaltedHash(authenticationRequest.Password);

                if (passwordHash.SequenceEqual(account.PasswordHash))
                {
                    var role = (UserRole) account.RoleId;
                    var token = JwtGenerator.GenerateToken(account.Id, role);

                    return TokenResponse.Success(token);
                }
            }

            return TokenResponse.Unauthorized();
        }

        public async Task<AccountResponse> GetIfExists(Guid id)
        {
            if (await AccountRepository.ExistsWithIdAsync(id))
            {
                var account = await AccountRepository.GetAsync(id);

                return AccountResponse.Success(account.FullName);
            }

            return AccountResponse.Unauthorized();
        }
    }
}