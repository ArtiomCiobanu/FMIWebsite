using NewsWebsiteAPI.Infrastructure.Enums;

namespace NewsWebsiteAPI.Infrastructure.Results
{
    public class BaseResult : IResult
    {
        public ResponseStatus Status { get; set; }
        public string Message { get; set; }

        public BaseResult()
        {
        }

        public BaseResult(ResponseStatus responseStatus)
        {
            Status = responseStatus;
        }

        public BaseResult(ResponseStatus responseStatus, string message)
        {
            Status = responseStatus;
            Message = message;
        }

        public static BaseResult Success() => new(ResponseStatus.Success);
        public static BaseResult Success(string message) => new(ResponseStatus.Success, message);
        public static BaseResult Fail() => new(ResponseStatus.InternalServerError);
        public static BaseResult Fail(string message) => new(ResponseStatus.InternalServerError, message);
        public static BaseResult Unauthorized(string message) => new BaseResult(ResponseStatus.Unauthorized, message);
    }
}