﻿using System;
using System.Threading.Tasks;
using NewsWebsiteAPI.DataAccess.Entities;
using NewsWebsiteAPI.DataAccess.Repositories;
using NewsWebsiteAPI.Infrastructure.Generators.Hashing;
using NewsWebsiteAPI.Infrastructure.Generators.Jwt;
using NewsWebsiteAPI.Infrastructure.Results;
using NewsWebsiteAPI.Models.Dto.Accounts;

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

        public async Task<Result> RegisterAsync(RegistrationModel registrationModel)
        {
            if (await AccountRepository.ExistsWithEmailAsync(registrationModel.Email))
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
            var account = await AccountRepository.GetWithEmailAsync(authenticationModel.Email);

            if (account != null)
            {
                var passwordHash = await HashGenerator.GenerateSaltedHash(authenticationModel.Password);

                if (account.PasswordHash == passwordHash)
                {
                    var token = JwtGenerator.GenerateToken(account.Id);

                    return Result.Success(token);
                }
            }

            return Result.Unauthorized("Email or password is incorrect.");
        }

        public async Task<Result> GetAccount(Guid id)
        {
            if (await AccountRepository.ExistsWithIdAsync(id))
            {
                var account = await AccountRepository.GetAsync(id);

                return Result.Success(account.FullName);
            }

            return Result.Unauthorized("User does not exist.");
        }
    }
}