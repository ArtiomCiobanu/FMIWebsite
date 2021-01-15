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
                Status = ResponseStatus.Failed
            };

        public static Result Fail(string message) =>
            new()
            {
                Status = ResponseStatus.Failed,
                Message = message
            };
    }
}