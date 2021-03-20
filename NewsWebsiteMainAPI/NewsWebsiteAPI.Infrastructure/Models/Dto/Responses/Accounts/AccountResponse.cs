using NewsWebsiteAPI.Infrastructure.Enums;
using NewsWebsiteAPI.Infrastructure.Models.Dto.Responses.Generic;

namespace NewsWebsiteAPI.Infrastructure.Models.Dto.Responses.Accounts
{
    public class AccountResponse : BaseResponse
    {
        public string FullName { get; private set; }

        public static AccountResponse Success(string fullName) =>
            new()
            {
                Status = ResponseStatus.Success,
                FullName = fullName
            };

        public static AccountResponse Unauthorized() =>
            new()
            {
                Status = ResponseStatus.Success
            };
    }
}