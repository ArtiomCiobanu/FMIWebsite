using NewsWebsiteAPI.Models.Dto.Accounts;

namespace NewsWebsiteAPI.DataAccess.Repositories
{
    public interface IAccountRepository
    {
        public bool ExistsWithEmail(string email);
        public void CreateUser(RegistrationModel registrationModel);
    }
}