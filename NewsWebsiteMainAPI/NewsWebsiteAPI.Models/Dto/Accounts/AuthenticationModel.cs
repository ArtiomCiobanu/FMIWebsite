using System.ComponentModel.DataAnnotations;

namespace NewsWebsiteAPI.Models.Dto.Accounts
{
    public class AuthenticationModel
    {
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
    }
}