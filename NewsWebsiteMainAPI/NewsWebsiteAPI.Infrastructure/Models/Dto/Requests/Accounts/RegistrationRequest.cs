﻿namespace NewsWebsiteAPI.Infrastructure.Models.Dto.Requests.Accounts
{
    public class RegistrationRequest
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
    }
}