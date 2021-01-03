using FMIWebsiteAPI.Models.Enums;
using Microsoft.AspNetCore.Authorization;

namespace FMIWebsiteAPI.API.Attributes
{
    public class AuthorizeUserAttribute : AuthorizeAttribute
    {
        public AuthorizeUserAttribute()
        {
        }

        public AuthorizeUserAttribute(UserRole userRole)
        {
            Roles = userRole.ToString();
        }
    }
}