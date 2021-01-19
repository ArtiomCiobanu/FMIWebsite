using System;
using System.ComponentModel.DataAnnotations;
using NewsWebsiteAPI.Infrastructure.Enums;

namespace NewsWebsiteAPI.DataAccess.Entities
{
    public class Account
    {
        public Guid Id { get; set; }
        public UserRole Role { get; set; }
        public string FullName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}