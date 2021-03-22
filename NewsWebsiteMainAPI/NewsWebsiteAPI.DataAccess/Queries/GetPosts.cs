using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NewsWebsiteAPI.DataAccess.Repositories;
using NewsWebsiteAPI.Infrastructure.Enums;
using NewsWebsiteAPI.Infrastructure.Models.Dto.Responses.Generic;
using NewsWebsiteAPI.Infrastructure.Models.Entities;

namespace NewsWebsiteAPI.DataAccess.Queries
{
    public class GetPosts
    {
        public class Request : IRequest<Response>
        {
            public int Limit { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private IPostRepository PostRepository { get; }

            public Handler(IPostRepository postRepository)
            {
                PostRepository = postRepository;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var posts = await PostRepository.GetTopAsync(request.Limit);

                return posts.Any() ?
                    Response.Success(posts) :
                    Response.NoContent();
            }
        }

        public class Response : BaseResponse
        {
            public Post[] Posts { get; set; }

            public static Response Success(Post[] posts) =>
                new()
                {
                    Posts = posts,
                    Status = ResponseStatus.Success
                };

            public static Response NoContent() =>
                new()
                {
                    //Posts = System.Array.Empty<Post>(),
                    Status = ResponseStatus.NoContent
                };
        }
    }
}