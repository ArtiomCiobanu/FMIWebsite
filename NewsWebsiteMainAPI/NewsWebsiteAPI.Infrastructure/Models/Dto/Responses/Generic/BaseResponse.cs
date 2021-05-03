using NewsWebsiteAPI.Infrastructure.Enums;

namespace NewsWebsiteAPI.Infrastructure.Models.Dto.Responses.Generic
{
    public class BaseResponse : IResponse
    {
        public ResponseStatus Status { get; set; }
    }
}