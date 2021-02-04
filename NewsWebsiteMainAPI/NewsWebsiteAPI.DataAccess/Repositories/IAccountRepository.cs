using System;
using System.Threading.Tasks;
using NewsWebsiteAPI.DataAccess.Entities;
using NewsWebsiteAPI.DataAccess.Repositories.Generic;

namespace NewsWebsiteAPI.DataAccess.Repositories
{
    public interface IAccountRepository : IRepository<Account>
    {
    }
}