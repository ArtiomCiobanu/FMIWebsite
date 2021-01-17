namespace NewsWebsiteAPI.Infrastructure.Enums
{
    public enum ResponseStatus
    {
        InternalServerError = -1,
        Success = 1,
        BadRequest = 2,
        Conflict = 3,
        NoContent = 4,
        NotFound = 5,
        Unauthorized = 6,
        Created = 7,
        Accepted = 8,
        PartialContent = 9,
        Forbidden = 10,
        TooManyRequests = 429
    }
}