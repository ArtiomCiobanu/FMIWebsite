using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NewsWebsiteAPI.DataAccess.Repositories;
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

            public Task<Response> Handle(Command command, CancellationToken cancellationToken)
            {
                var post = new Post()
                {
                    Title = command.Content,
                    Content = command.Content
                };

                PostRepository.CreateAsync(post);

                return Task.FromResult(new Response());
            }
        }

        public class Response : BaseResponse
        {
        }
    }
}