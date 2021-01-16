using NewsWebsiteAPI.Models.Dto.Accounts;

namespace NewsWebsiteAPI.DataAccess.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public bool ExistsWithEmail(string email)
        {
            return true;
        }

        public void CreateUser(RegistrationModel registrationModel)
        {
        }
    }
}