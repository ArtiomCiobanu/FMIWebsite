using NewsWebsiteAPI.Infrastructure.Enums;

namespace NewsWebsiteAPI.Infrastructure.Results
{
    public class Result : IResult
    {
        public ResponseStatus Status { get; set; }
        public string Message { get; set; }

        public Result()
        {
        }

        public Result(ResponseStatus responseStatus)
        {
            Status = responseStatus;
        }

        public Result(ResponseStatus responseStatus, string message)
        {
            Status = responseStatus;
            Message = message;
        }

        public static Result Success() => new(ResponseStatus.Success);
        public static Result Success(string message) => new(ResponseStatus.Success, message);
        public static Result Fail() => new(ResponseStatus.InternalServerError);
        public static Result Fail(string message) => new(ResponseStatus.InternalServerError, message);
        public static Result Unauthorized(string message) => new Result(ResponseStatus.Unauthorized, message);
    }
}