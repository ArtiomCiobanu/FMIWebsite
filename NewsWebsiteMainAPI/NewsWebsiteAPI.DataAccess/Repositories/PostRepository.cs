using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsWebsiteAPI.DataAccess.Context;
using NewsWebsiteAPI.Infrastructure.Models.Entities;

namespace NewsWebsiteAPI.DataAccess.Repositories
{
    public class PostRepository : IPostRepository
    {
        private IPostContext PostContext { get; }

        public PostRepository(IPostContext postContext)
        {
            PostContext = postContext;
        }

        public async Task CreateAsync(Post post)
        {
            await PostContext.Posts.AddAsync(post);
            await PostContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Post post)
        {
            PostContext.Posts.Update(post);
            await PostContext.SaveChangesAsync();
        }

        public async Task<Post> GetAsync(Guid id)
            => await PostContext.Posts.FindAsync(id);

        public async Task DeleteAsync(Guid id)
        {
            var post = await GetAsync(id);

            PostContext.Posts.Remove(post);
            await PostContext.SaveChangesAsync();
        }

        public Task<bool> ExistsWithIdAsync(Guid id)
            => PostContext.Posts.AnyAsync(post => post.Id == id);
    }
}