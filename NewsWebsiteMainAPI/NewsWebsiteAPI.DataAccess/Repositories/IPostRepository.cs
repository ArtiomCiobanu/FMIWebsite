using System.Threading.Tasks;
using NewsWebsiteAPI.DataAccess.Repositories.Generic;
using NewsWebsiteAPI.Infrastructure.Models.Entities;

namespace NewsWebsiteAPI.DataAccess.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        public Task<Post[]> GetTopAsync(int amount);
    }
}