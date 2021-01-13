using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsWebsiteAPI.Models.Dto.Accounts;
using NewsWebsiteAPI.Shared.Consts;
using NewsWebsiteAPI.Shared.Extentions;
using AppClaimTypes = NewsWebsiteAPI.Consts.AppClaimTypes;

namespace NewsWebsiteAPI.Controllers
{
    [ApiController]
    [Route("accounts")]
    public class AccountsController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public ActionResult<string> LogIn([FromBody] AuthenticationModel model)
        {
            return Ok();
        }

        [HttpPost]
        [Route("register")]
        public ActionResult<string> Register([FromBody]RegistrationModel model)
        {
            return Ok();
        }

        [HttpGet]
        [Route("get_account")]
        [Authorize]
        public ActionResult<Guid> GetAccountData()
        {
            var id = Guid.Parse(User.GetClaim(AppClaimTypes.UserId).Value);

            return Ok(id);
        }
    }
}