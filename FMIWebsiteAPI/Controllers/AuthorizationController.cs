using FMIWebsiteAPI.Models.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FMIWebsiteAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AuthorizationController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        [Route("LogIn")]
        public IActionResult LogIn([FromBody] AccountAuthenticationModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Log in logic here

            return Ok();
        }
    }
}