﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NewsWebsiteAPI.Consts;
using NewsWebsiteAPI.Controllers.Base;
using NewsWebsiteAPI.DataAccess.Commands;
using NewsWebsiteAPI.DataAccess.Queries;

namespace NewsWebsiteAPI.Controllers
{
    //[DisableCors]
    [EnableCors]
    [Route("posts")]
    public class PostController : BaseController
    {
        private IMediator Mediator { get; }

        public PostController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpPost("add")]
        [Authorize(Policy = PolicyNames.RequireAdministratorRole)]
        public Task<ActionResult<AddPost.AddPostResponse>> AddPost(
            [Required] [FromBody] AddPost.Command command)
            => ExecuteAction(() => Mediator.Send(command));

        [HttpGet("get/{limit?}")]
        public Task<ActionResult<GetPosts.GetPostsResponse>> GetPosts(int limit = 10)
            => ExecuteAction(() => Mediator.Send(
                new GetPosts.Request
                {
                    Limit = limit
                }));


        [HttpGet("{postId}")]
        public Task<ActionResult<GetPostById.GetPostByIdResponse>> GetPost(
            [Required] [FromRoute] Guid postId)
            => ExecuteAction(() => Mediator.Send(
                new GetPostById.Request
                {
                    PostId = postId
                }));
    }
}