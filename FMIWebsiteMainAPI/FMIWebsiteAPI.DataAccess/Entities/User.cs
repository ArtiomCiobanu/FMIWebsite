using System;
using FMIWebsiteAPI.Models.Enums;

namespace FMIWebsiteAPI.DataAccess.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public UserRole Role { get; set; }
        public string FullName { get; set; }
    }
}