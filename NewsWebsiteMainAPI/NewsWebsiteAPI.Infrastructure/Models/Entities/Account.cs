using System;
using System.ComponentModel.DataAnnotations;

namespace NewsWebsiteAPI.Infrastructure.Models.Entities
{
    public class Account
    {
        public Guid Id { get; set; }
        public int RoleId { get; set; }
        public string FullName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string PasswordHash { get; set; }
    }
}