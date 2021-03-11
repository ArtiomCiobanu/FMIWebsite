using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NewsWebsiteAPI.Infrastructure.Models.Dto.Responses.Generic;

namespace NewsWebsiteAPI.DataAccess.Commands
{
    public static class AddPost
    {
        public class Command : IRequest<Response>
        {
        }

        public class Handler : IRequestHandler<Command, Response>
        {
            public Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }
        }

        public class Response : BaseResponse
        {
        }
    }
}