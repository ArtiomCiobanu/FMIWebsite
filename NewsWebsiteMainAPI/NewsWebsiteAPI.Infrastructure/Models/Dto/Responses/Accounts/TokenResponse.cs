using NewsWebsiteAPI.Infrastructure.Enums;
using NewsWebsiteAPI.Infrastructure.Models.Dto.Responses.Generic;

namespace NewsWebsiteAPI.Infrastructure.Models.Dto.Responses.Accounts
{
    public class TokenResponse : BaseResponse
    {
        public string Token { get; private set; }

        public static TokenResponse Success(string token) =>
            new()
            {
                Status = ResponseStatus.Success,
                Token = token
            };

        public static TokenResponse Unauthorized() =>
            new()
            {
                Status = ResponseStatus.Unauthorized
            };
    }
}