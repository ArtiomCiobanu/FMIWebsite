using NewsWebsiteAPI.Infrastructure.Enums;

namespace NewsWebsiteAPI.Infrastructure.Models.Results
{
    public interface IResponse
    {
        public ResponseStatus Status { get; }
    }
}