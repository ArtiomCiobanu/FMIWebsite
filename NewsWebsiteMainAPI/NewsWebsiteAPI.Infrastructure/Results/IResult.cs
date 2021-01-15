using NewsWebsiteAPI.Infrastructure.Enums;

namespace NewsWebsiteAPI.Infrastructure.Results
{
    public interface IResult
    {
        public ResponseStatus Status { get; set; }
    }
}