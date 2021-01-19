using System;
using NewsWebsiteAPI.Infrastructure.Enums;

namespace NewsWebsiteAPI.DataAccess.Entities
{
    public class Account
    {
        public Guid Id { get; set; }
        public UserRole Role { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}