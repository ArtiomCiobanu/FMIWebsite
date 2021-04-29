using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsWebsiteAPI.Infrastructure.Constants;
using NewsWebsiteAPI.Infrastructure.Enums;
using NewsWebsiteAPI.Infrastructure.Extensions;
using NewsWebsiteAPI.Infrastructure.Generators.Jwt;
using NewsWebsiteAPI.Infrastructure.Handlers;
using PolicyNames = NewsWebsiteAPI.Consts.PolicyNames;

namespace NewsWebsiteAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class JwtTestController : ControllerBase
    {
        private IJwtReader JwtReader { get; }
        private IJwtGenerator JwtGenerator { get; }

        public JwtTestController(IJwtReader jwtReader, IJwtGenerator jwtGenerator)
        {
            JwtReader = jwtReader;
            JwtGenerator = jwtGenerator;
        }

        [HttpGet]
        [Authorize(Policy = PolicyNames.RequireAdministratorRole)]
        public IActionResult AdminTest()
        {
            return Ok("You're an admin!");
        }

        [HttpGet]
        [Authorize]
        public IActionResult AuthorizeTest()
        {
            return Ok("You are authorized!");
        }

        [HttpGet]
        public IActionResult AnonymousTest()
        {
            return Ok("Hi!");
        }

        [HttpGet]
        public IActionResult GetUserToken()
        {
            return Ok(JwtGenerator.GenerateToken(Guid.NewGuid(), UserRole.User));
        }

        [HttpGet]
        public IActionResult GetAdminToken()
        {
            return Ok(JwtGenerator.GenerateToken(Guid.NewGuid(), UserRole.Admin));
        }

        [HttpGet]
        public IActionResult GetTokenData(string token)
        {
            var id = JwtReader.GetUserIdFromToken(token);
            var role = JwtReader.GetUserRoleFromToken(token);

            var result = $"ID: {id}\nRole: {role}";
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetUserId()
        {
            var user = User;
            var id = User.GetClaim(AppClaimTypes.UserId);

            return Ok();
        }
    }
}