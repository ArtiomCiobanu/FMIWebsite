namespace NewsWebsiteAPI.Infrastructure.Enums
{
    public enum ResponseStatus
    {
        //
        // Summary:
        //     Maps to http status code 500 - Internal server error
        Failed = -1,

        //
        // Summary:
        //     Maps to http status code 200 - OK result
        Success = 1,

        //
        // Summary:
        //     Maps to http status code 400 - Bad Request
        BadRequest = 2,

        //
        // Summary:
        //     Maps to http status code 409 - Conflict
        Conflict = 3,

        //
        // Summary:
        //     Maps to http status code 204 - No Content
        NoContent = 4,

        //
        // Summary:
        //     Maps to http status code 404 - Not Found
        NotFound = 5,

        //
        // Summary:
        //     Maps to http status code 401 - Unauthorized
        Unauthorized = 6,

        //
        // Summary:
        //     Maps to http status code 201 - Created
        Created = 7,

        //
        // Summary:
        //     Maps to http status code 202 - Accepted
        Accepted = 8,

        //
        // Summary:
        //     Maps to http status code 206 - Partial content
        PartialContent = 9,

        //
        // Summary:
        //     Maps to http status code 403 - Forbidden
        Forbidden = 10,

        //
        // Summary:
        //     Maps to http status code 429 - Too Many Requests
        TooManyRequests = 429
    }
}