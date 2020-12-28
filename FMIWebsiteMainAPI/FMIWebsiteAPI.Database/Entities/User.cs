using System;
using FMIWebsiteAPI.Models.Accounts;

namespace FMIWebsiteAPI.Database.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public UserRole Role { get; set; }
        public string FullName { get; set; }
    }
}