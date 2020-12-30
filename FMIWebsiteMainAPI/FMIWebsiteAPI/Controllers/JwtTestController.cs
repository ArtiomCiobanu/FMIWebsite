using System;
using FMIWebsiteAPI.Models.Enums;
using FMIWebsiteAPI.Shared.Consts;
using FMIWebsiteAPI.Shared.Extentions;
using FMIWebsiteAuthorizationAPI.Generators;
using FMIWebsiteAuthorizationAPI.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FMIWebsiteAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class JwtTestController : ControllerBase
    {
        private IJwtHandler JwtHandler { get; }
        private IJwtGenerator JwtGenerator { get; }

        public JwtTestController(IJwtHandler jwtHandler, IJwtGenerator jwtGenerator)
        {
            JwtHandler = jwtHandler;
            JwtGenerator = jwtGenerator;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
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
        [AllowAnonymous]
        public IActionResult AnonymousTest()
        {
            return Ok("Hi!");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetUserToken()
        {
            return Ok(JwtGenerator.GenerateToken(Guid.NewGuid(), UserRole.User));
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAdminToken()
        {
            return Ok(JwtGenerator.GenerateToken(Guid.NewGuid(), UserRole.Admin));
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetTokenData(string token)
        {
            var id = JwtHandler.GetUserIdFromToken(token);
            var role = JwtHandler.GetUserRoleFromToken(token);

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