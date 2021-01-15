using System;
using NewsWebsiteAPI.Infrastructure.Enums;

namespace NewsWebsiteAPI.DataAccess.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public UserRole Role { get; set; }
        public string FullName { get; set; }
    }
}