namespace NewsWebsiteAPI.Infrastructure.Repositories
{
    public interface IAccountRepository
    {
        public bool ExistsWithEmail(string email);
        public void CreateUser();
    }
}