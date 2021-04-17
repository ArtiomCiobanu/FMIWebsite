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
        public class Command : IRequest<AddPostResponse>
        {
            public string Title { get; set; }
            public string Content { get; set; }
        }

        public class Handler : IRequestHandler<Command, AddPostResponse>
        {
            private IPostRepository PostRepository { get; }

            public Handler(IPostRepository postRepository)
            {
                PostRepository = postRepository;
            }

            public async Task<AddPostResponse> Handle(Command command, CancellationToken cancellationToken)
            {
                var post = new Post
                {
                    Title = command.Title,
                    Content = command.Content
                };

                await PostRepository.CreateAsync(post);
                await PostRepository.SaveChangesAsync();

                return AddPostResponse.Success();
            }
        }

        public class AddPostResponse : BaseResponse
        {
            public static AddPostResponse Success() =>
                new()
                {
                    Status = ResponseStatus.Success
                };
        }
    }
}