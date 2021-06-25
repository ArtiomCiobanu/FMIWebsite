namespace NewsWebsiteAPI.Infrastructure.Models.Entities
{
    public class Account : BaseEntity
    {
        public int RoleId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
    }
}