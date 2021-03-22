using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NewsWebsiteAPI.DataAccess.Repositories;
using NewsWebsiteAPI.Infrastructure.Enums;
using NewsWebsiteAPI.Infrastructure.Models.Dto.Responses.Generic;
using NewsWebsiteAPI.Infrastructure.Models.Entities;

namespace NewsWebsiteAPI.DataAccess.Commands
{
    public static class AddPost
    {
        public class Command : IRequest<Response>
        {
            public string Title { get; set; }
            public string Content { get; set; }
        }

        public class Handler : IRequestHandler<Command, Response>
        {
            private IPostRepository PostRepository { get; }

            public Handler(IPostRepository postRepository)
            {
                PostRepository = postRepository;
            }

            public async Task<Response> Handle(Command command, CancellationToken cancellationToken)
            {
                var post = new Post
                {
                    Title = command.Title,
                    Content = command.Content
                };

                await PostRepository.CreateAsync(post);

                return Response.Success();
            }
        }

        public class Response : BaseResponse
        {
            public static Response Success() =>
                new()
                {
                    Status = ResponseStatus.Success
                };
        }
    }
}