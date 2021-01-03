using System.ComponentModel.DataAnnotations;

namespace FMIWebsiteAPI.Models.Dto.Accounts
{
    public class AccountAuthenticationModel
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