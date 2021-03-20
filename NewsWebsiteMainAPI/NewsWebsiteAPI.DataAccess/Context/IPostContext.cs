using Microsoft.EntityFrameworkCore;
using NewsWebsiteAPI.DataAccess.Context.Generic;
using NewsWebsiteAPI.Infrastructure.Models.Entities;

namespace NewsWebsiteAPI.DataAccess.Context
{
    public interface IPostContext : IBaseContext
    {
        public DbSet<Post> Posts { get; set; }
    }
}