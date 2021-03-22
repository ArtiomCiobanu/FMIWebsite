using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NewsWebsiteAPI.DataAccess.Repositories;
using NewsWebsiteAPI.Infrastructure.Enums;
using NewsWebsiteAPI.Infrastructure.Models.Dto.Responses.Generic;
using NewsWebsiteAPI.Infrastructure.Models.Entities;

namespace NewsWebsiteAPI.DataAccess.Queries
{
    public class GetPostById
    {
        public class Request : IRequest<GetPostByIdResponse>
        {
            public Guid PostId { get; set; }
        }

        public class Handler : IRequestHandler<Request, GetPostByIdResponse>
        {
            private IPostRepository PostRepository { get; }

            public Handler(IPostRepository postRepository)
            {
                PostRepository = postRepository;
            }

            public async Task<GetPostByIdResponse> Handle(Request request, CancellationToken cancellationToken)
            {
                if (request.PostId == default)
                {
                    return GetPostByIdResponse.BadRequest();
                }

                var post = await PostRepository.GetAsync(request.PostId);

                return post != null ?
                    GetPostByIdResponse.Success(post) :
                    GetPostByIdResponse.NotFound();
            }
        }

        public class GetPostByIdResponse : BaseResponse
        {
            public Post Post { get; set; }

            public static GetPostByIdResponse Success(Post post) =>
                new()
                {
                    Status = ResponseStatus.Success,
                    Post = post
                };

            public static GetPostByIdResponse BadRequest() =>
                new()
                {
                    Status = ResponseStatus.BadRequest
                };

            public static GetPostByIdResponse NotFound() =>
                new()
                {
                    Status = ResponseStatus.NotFound
                };
        }
    }
}