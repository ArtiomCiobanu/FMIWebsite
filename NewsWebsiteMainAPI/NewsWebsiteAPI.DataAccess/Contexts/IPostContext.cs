using Microsoft.EntityFrameworkCore;
using NewsWebsiteAPI.Infrastructure.Models.Entities;

namespace NewsWebsiteAPI.DataAccess.Contexts
{
    public interface IPostContext 
    {
        public DbSet<Post> Posts { get; set; }
    }
}