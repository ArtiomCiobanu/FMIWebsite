using NewsWebsiteAPI.Infrastructure.Enums;
using NewsWebsiteAPI.Infrastructure.Models.Results;

namespace NewsWebsiteAPI.Infrastructure.Models.Dto.Responses.Generic
{
    public class BaseResponse : IResponse
    {
        public ResponseStatus Status { get; set; }
        public string Message { get; set; }

        public BaseResponse()
        {
        }

        public BaseResponse(ResponseStatus responseStatus)
        {
            Status = responseStatus;
        }

        public BaseResponse(ResponseStatus responseStatus, string message)
        {
            Status = responseStatus;
            Message = message;
        }

        public static BaseResponse Success() => new(ResponseStatus.Success);
        public static BaseResponse Success(string message) => new(ResponseStatus.Success, message);
        public static BaseResponse Fail() => new(ResponseStatus.InternalServerError);
        public static BaseResponse Fail(string message) => new(ResponseStatus.InternalServerError, message);
        public static BaseResponse Unauthorized(string message) => new BaseResponse(ResponseStatus.Unauthorized, message);
    }
}