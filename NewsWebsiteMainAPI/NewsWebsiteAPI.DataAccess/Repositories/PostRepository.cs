using System;
using System.Collections.Generic;
using System.Linq;
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
            await PostContext.DataSet.AddAsync(post);
            await PostContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Post post)
        {
            PostContext.DataSet.Update(post);
            await PostContext.SaveChangesAsync();
        }

        public async Task<Post> GetAsync(Guid id)
            => await PostContext.DataSet.FindAsync(id);

        public async Task DeleteAsync(Guid id)
        {
            var post = await GetAsync(id);

            PostContext.DataSet.Remove(post);
            await PostContext.SaveChangesAsync();
        }

        public Task<bool> ExistsWithIdAsync(Guid id)
            => PostContext.DataSet.AnyAsync(post => post.Id == id);

        public async Task<Post[]> GetTopAsync(int amount)
        {
            var result = PostContext.DataSet.OrderByDescending(x => x.Title).Take(amount).ToArray();
            return await Task.FromResult(result);
        }
    }
}