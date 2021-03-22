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
        public class Request : IRequest<GetPostsResponse>
        {
            public int Limit { get; set; }
        }

        public class Handler : IRequestHandler<Request, GetPostsResponse>
        {
            private const int MaxLimit = 100;
            private IPostRepository PostRepository { get; }

            public Handler(IPostRepository postRepository)
            {
                PostRepository = postRepository;
            }

            public async Task<GetPostsResponse> Handle(Request request, CancellationToken cancellationToken)
            {
                if (request.Limit > MaxLimit)
                {
                    request.Limit = MaxLimit;
                }

                var posts = await PostRepository.GetTopAsync(request.Limit);

                return posts.Any() ?
                    GetPostsResponse.Success(posts) :
                    GetPostsResponse.NoContent();
            }
        }

        public class GetPostsResponse : BaseResponse
        {
            public Post[] Posts { get; set; }

            public static GetPostsResponse Success(Post[] posts) =>
                new()
                {
                    Posts = posts,
                    Status = ResponseStatus.Success
                };

            public static GetPostsResponse NoContent() =>
                new()
                {
                    //Posts = System.Array.Empty<Post>(),
                    Status = ResponseStatus.NoContent
                };
        }
    }
}