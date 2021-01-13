namespace NewsWebsiteAPI.Infrastructure.Results
{
    public class Result : ResultBase
    {
        
        public static Result Success() =>
            new()
            {
                Succeeded = true
            };

        public static Result Fail() =>
            new()
            {
                Succeeded = false
            };

        public static Result Fail(string message) =>
            new()
            {
                Succeeded = false,
                Message = message
            };
    }
}