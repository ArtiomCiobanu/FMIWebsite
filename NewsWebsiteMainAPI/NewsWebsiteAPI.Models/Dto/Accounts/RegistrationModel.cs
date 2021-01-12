using System.ComponentModel.DataAnnotations;

namespace NewsWebsiteAPI.Models.Dto.Accounts
{
    public class RegistrationModel
    {
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
    }
}