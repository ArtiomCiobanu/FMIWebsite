using System;
using System.Threading.Tasks;
using NewsWebsiteAPI.DataAccess.Context;
using NewsWebsiteAPI.Infrastructure.Models.Entities;

namespace NewsWebsiteAPI.DataAccess.Repositories
{
    public class PostRepository : IPostRepository
    {
        private PostContext PostContext { get; }

        public PostRepository(PostContext postContext)
        {
            PostContext = postContext;
        }

        public async Task CreateAsync(Post post)
        {
            await PostContext.Posts.AddAsync(post);
            await PostContext.SaveChangesAsync();
        }

        public Task UpdateAsync(Post account)
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsWithIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}