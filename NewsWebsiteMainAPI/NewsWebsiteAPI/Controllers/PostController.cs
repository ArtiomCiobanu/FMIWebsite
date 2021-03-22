using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewsWebsiteAPI.Controllers.Base;
using NewsWebsiteAPI.DataAccess.Commands;
using NewsWebsiteAPI.DataAccess.Queries;

namespace NewsWebsiteAPI.Controllers
{
    [Route("posts")]
    public class PostController : BaseController
    {
        private IMediator Mediator { get; }

        public PostController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpPost("add")]
        public Task<ActionResult<AddPost.Response>> AddPost(
            [Required] [FromBody] AddPost.Command command)
            => ExecuteAction(() => Mediator.Send(command));

        [HttpGet("{limit}")]
        public Task<ActionResult<GetPosts.Response>> Test(
            [Required] [FromRoute] int limit)
            => ExecuteAction(() => Mediator.Send(
                new GetPosts.Request
                {
                    Limit = limit
                }));

        /*ExecuteAction(() => Mediator.Send(
                new GetPosts.Request
                {
                    Limit = limit
                }));*/

        /*[HttpGet("{amount}")]
        public Task<ActionResult<GetPosts.Response>> GetPosts(
                [Required] [FromBody] GetPosts.Request request)
            //[Required] [FromRoute] int amount)
            => ExecuteAction(() => Mediator.Send(request));*/


        /*[HttpGet("{postId}")]
        public Task<IActionResult> GetPost()
        {
        }*/
    }
}