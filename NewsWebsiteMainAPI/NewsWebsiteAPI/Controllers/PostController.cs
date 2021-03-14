using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewsWebsiteAPI.Controllers.Base;
using NewsWebsiteAPI.DataAccess.Commands;

namespace NewsWebsiteAPI.Controllers
{
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


        /*[HttpGet]
        public Task<IActionResult> GetPosts()
        {
        }

        [HttpGet("{postId}")]
        public Task<IActionResult> GetPost()
        {
        }*/
    }
}