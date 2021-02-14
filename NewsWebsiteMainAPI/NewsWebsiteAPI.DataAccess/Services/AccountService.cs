using System;
using System.Threading.Tasks;
using NewsWebsiteAPI.DataAccess.Entities;
using NewsWebsiteAPI.DataAccess.Repositories;
using NewsWebsiteAPI.Infrastructure.Generators.Hashing;
using NewsWebsiteAPI.Infrastructure.Results;
using NewsWebsiteAPI.Models.Dto.Accounts;

namespace NewsWebsiteAPI.DataAccess.Services
{
    public class AccountService : IAccountService
    {
        private IAccountRepository AccountRepository { get; }
        private IHashGenerator HashGenerator { get; }

        public AccountService(IAccountRepository accountRepository, IHashGenerator hashGenerator)
        {
            AccountRepository = accountRepository;
            HashGenerator = hashGenerator;
        }

        public async Task<Result> RegisterAsync(RegistrationModel registrationModel)
        {
            if (await ExistsWithEmailAsync(registrationModel.Email))
            {
                return Result.Unauthorized("There is already a user with this email!");
            }

            var passwordHash = await HashGenerator.GenerateSaltedHash(registrationModel.Password);

            await AccountRepository.CreateAsync(new Account
            {
                Id = Guid.NewGuid(),
                Email = registrationModel.Email,
                FullName = registrationModel.FullName,
                RoleId = 0, //UserRole.User
                PasswordHash = passwordHash
            });

            return Result.Success("Created");
        }

        public async Task<Result> LogInAsync(AuthenticationModel authenticationModel)
        {
            var user = await AccountRepository.GetWithEmailAsync(authenticationModel.Email);

            if (user != null)
            {
                var passwordHash = await HashGenerator.GenerateSaltedHash(authenticationModel.Password);

                if (user.PasswordHash == passwordHash)
                {
                    return Result.Success();
                }
            }

            return Result.Unauthorized("Email or password is incorrect.");
        }

        public async Task<bool> ExistsWithIdAsync(Guid userId)
        {
            var user = await AccountRepository.GetAsync(userId);
            return user != null;
        }

        public async Task<bool> ExistsWithEmailAsync(string email)
        {
            var foundUser = await AccountRepository.GetWithEmailAsync(email);

            return foundUser != null;
        }
    }
}