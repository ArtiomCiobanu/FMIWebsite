using System.Linq;
using System.Threading.Tasks;
using NewsWebsiteAPI.DataAccess.Context;
using NewsWebsiteAPI.DataAccess.Repositories.Generic;
using NewsWebsiteAPI.Infrastructure.Models.Entities;

namespace NewsWebsiteAPI.DataAccess.Repositories
{
    public class PostRepository : EfBaseRepository<Post>, IPostRepository
    {
        private PostContext PostContext { get; }

        public PostRepository(PostContext postContext) : base(postContext)
        {
            PostContext = postContext;
        }

        public async Task<Post[]> GetTopAsync(int amount)
        {
            var result = PostContext.Posts.OrderByDescending(x => x.Title).Take(amount).ToArray();
            return await Task.FromResult(result);
        }
    }
}