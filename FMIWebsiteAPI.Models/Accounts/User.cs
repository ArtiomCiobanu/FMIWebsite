using System;

namespace FMIWebsiteAPI.Models.Accounts
{
    public class User
    {
        public UserRole Role { get; set; }
        public Guid Id { get; set; }

        public User()
        {
        }

        public User(Guid id, UserRole role)
        {
            Id = id;
            Role = role;
        }
    }
}