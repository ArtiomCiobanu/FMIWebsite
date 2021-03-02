using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsWebsiteAPI.Controllers.Base;
using NewsWebsiteAPI.DataAccess.Services;
using NewsWebsiteAPI.Infrastructure.Constants;
using NewsWebsiteAPI.Infrastructure.Extensions;
using NewsWebsiteAPI.Infrastructure.Models.Dto.Requests.Accounts;

namespace NewsWebsiteAPI.Controllers
{
    [ApiController]
    [Route("accounts")]
    public class AccountController : BaseController
    {
        private IAccountService AccountService { get; }

        public AccountController(IAccountService accountService)
        {
            AccountService = accountService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<string>> LogIn(
            [Required] [FromBody] AuthenticationRequest request)
            => await ExecuteAction(() => AccountService.LogInAsync(request));

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<string>> Register(
            [Required] [FromBody] RegistrationRequest request)
            => await ExecuteAction(() => AccountService.RegisterAsync(request));

        [HttpGet]
        [Route("get_account")]
        [Authorize]
        public async Task<ActionResult<string>> GetAccount()
        {
            var id = Guid.Parse(User.GetClaim(AppClaimTypes.UserId).Value);

            return await ExecuteAction(() => AccountService.GetIfExists(id));
        }
    }
}