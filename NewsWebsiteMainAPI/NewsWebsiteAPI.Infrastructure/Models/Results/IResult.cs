using NewsWebsiteAPI.Infrastructure.Enums;

namespace NewsWebsiteAPI.Infrastructure.Models.Results
{
    public interface IResult
    {
        public ResponseStatus Status { get; }
    }
}