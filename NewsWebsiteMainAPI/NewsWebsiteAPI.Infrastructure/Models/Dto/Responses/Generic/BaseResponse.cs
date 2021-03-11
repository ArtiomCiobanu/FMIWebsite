using NewsWebsiteAPI.Infrastructure.Enums;

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

        protected static BaseResponse Success() => new(ResponseStatus.Success);
        protected static BaseResponse Fail() => new(ResponseStatus.InternalServerError);
        protected static BaseResponse Fail(string message) => new(ResponseStatus.InternalServerError, message);
        protected static BaseResponse Unauthorized(string message) => new(ResponseStatus.Unauthorized, message);
    }
}