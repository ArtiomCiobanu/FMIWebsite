﻿using System;
using FMIWebsiteAPI.Models.Accounts;
using FMIWebsiteAPI.Shared.Consts;
using FMIWebsiteAPI.Shared.Extentions;
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
        public IActionResult GetAdminToken()
        {
            return Ok(JwtManager.GenerateToken(Guid.NewGuid(), UserRole.Admin));
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
            var id = User.GetClaim(AppClaimTypes.UserId);

            return Ok();
        }
    }
}