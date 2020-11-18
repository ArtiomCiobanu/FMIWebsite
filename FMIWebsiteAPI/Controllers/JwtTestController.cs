using FMIWebsiteAPI.Models.Accounts;
using FMIWebsiteAuthorizationAPI.API;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FMIWebsiteAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class JwtTestController : ControllerBase
    {
        private IJwtManager JwtManager { get; set; }

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
            return Ok(JwtManager.GenerateToken("Test", UserRole.User.ToString()));
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAdminToken(string userName)
        {
            return Ok(JwtManager.GenerateToken(userName, UserRole.Admin.ToString()));
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
    }
}