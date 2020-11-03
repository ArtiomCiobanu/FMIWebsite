namespace FMIWebsiteAPI.Models.Accounts
{
    public class User
    {
        public UserRole Role { get; private set; }
        public string Id { get; }

        public User(string id, UserRole role)
        {
            Id = id;
            Role = role;
        }

        public void SetRole(UserRole newRole)
        {
            Role = newRole;
        }

        public string GetStringRole() => Role.ToString();
    }
}