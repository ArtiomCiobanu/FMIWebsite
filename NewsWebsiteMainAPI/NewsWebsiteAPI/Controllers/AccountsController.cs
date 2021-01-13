using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsWebsiteAPI.Controllers.Base;
using NewsWebsiteAPI.Infrastructure.Services;
using NewsWebsiteAPI.Models.Dto.Accounts;
using NewsWebsiteAPI.Shared.Consts;
using NewsWebsiteAPI.Shared.Extentions;

namespace NewsWebsiteAPI.Controllers
{
    [ApiController]
    [Route("accounts")]
    public class AccountsController : BaseController
    {
        private IAccountService AccountService { get; }

        public AccountsController(IAccountService accountService)
        {
            AccountService = accountService;
        }

        [HttpPost]
        [Route("login")]
        public ActionResult<string> LogIn([FromBody] AuthenticationModel model)
        {
            return Ok();
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] RegistrationModel model)
            => ExecuteAction(
                () => AccountService.Register(model),
                Ok,
                Conflict);

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