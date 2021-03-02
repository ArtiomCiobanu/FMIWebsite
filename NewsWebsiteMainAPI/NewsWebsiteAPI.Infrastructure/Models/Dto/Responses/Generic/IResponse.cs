using NewsWebsiteAPI.Infrastructure.Enums;

namespace NewsWebsiteAPI.Infrastructure.Models.Dto.Responses.Generic
{
    public interface IResponse
    {
        public ResponseStatus Status { get; }
    }
}