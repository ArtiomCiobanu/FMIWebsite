using FMIWebsiteAPI.Models.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FMIWebsiteAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountsController : ControllerBase
    {
        [HttpPost]
        [Route("LogIn")]
        public ActionResult<string> LogIn([FromBody] AccountAuthenticationModel model)
        {
            return Ok();
        }

        [HttpPost]
        [Route("Register")]
        public ActionResult<string> Register()
        {
            return Ok();
        }
    }
}