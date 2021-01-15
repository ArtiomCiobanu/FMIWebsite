using NewsWebsiteAPI.Infrastructure.Enums;

namespace NewsWebsiteAPI.Infrastructure.Results
{
    public class Result : ResultBase
    {
        public string Message { get; set; }

        public static Result Success() =>
            new()
            {
                Status = ResponseStatus.Success
            };

        public static Result Success(string message) =>
            new()
            {
                Status = ResponseStatus.Success,
                Message = message
            };

        public static Result Fail() =>
            new()
            {
                Status = ResponseStatus.InternalServerError
            };

        public static Result Fail(string message) =>
            new()
            {
                Status = ResponseStatus.InternalServerError,
                Message = message
            };
    }
}