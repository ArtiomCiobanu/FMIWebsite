using System;
using NewsWebsiteAPI.Infrastructure.Enums;
using NewsWebsiteAPI.Infrastructure.Models.Dto.Responses.Generic;

namespace NewsWebsiteAPI.Infrastructure.Models.Dto.Responses.Accounts
{
    public class AccountResponse : BaseResponse
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; }

        public static AccountResponse Success(Guid id, string fullName) =>
            new()
            {
                Id = id,
                Status = ResponseStatus.Success,
                FullName = fullName
            };
    }
}