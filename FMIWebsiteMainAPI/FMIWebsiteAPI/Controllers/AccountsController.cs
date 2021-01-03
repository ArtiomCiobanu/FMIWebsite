using FMIWebsiteAPI.Models.Dto.Accounts;
using Microsoft.AspNetCore.Mvc;

namespace FMIWebsiteAPI.Controllers
{
    [ApiController]
    [Route("accounts")]
    public class AccountsController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public ActionResult<string> LogIn([FromBody] AccountAuthenticationModel model)
        {
            return Ok();
        }

        [HttpPost]
        [Route("register")]
        public ActionResult<string> Register()
        {
            return Ok();
        }
    }
}