using System;
using System.Linq;
using FMIWebsiteAPI.Configuration;
using FMIWebsiteAPI.Models.Accounts;
using FMIWebsiteAPI.Shared;
using FMIWebsiteAuthorizationAPI.API;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FMIWebsiteAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class JwtTestController : ControllerBase
    {
        private IJwtManager JwtManager { get; }

        public JwtTestController(IJwtManager jwtManager)
        {
            JwtManager = jwtManager;
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
            return Ok(JwtManager.GenerateToken(Guid.NewGuid(), UserRole.User));
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAdminToken(Guid userId)
        {
            return Ok(JwtManager.GenerateToken(userId, UserRole.Admin));
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetTokenData(string token)
        {
            var id = JwtManager.GetUserIdFromToken(token);
            var role = JwtManager.GetUserRoleFromToken(token);

            var result = $"ID: {id}\nRole: {role}";
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetUserId()
        {
            var user = User;
            var id = user.Claims.Where(c => c.Type == EndpointConstNames.UserIdClaim);
            
            return Ok();
        }
    }
}