using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NewsWebsiteAPI.DataAccess.Context.Generic;
using NewsWebsiteAPI.Infrastructure.Models.Entities;

namespace NewsWebsiteAPI.DataAccess.Context
{
    public class PostContext : BaseContext, IPostContext
    {
        public DbSet<Post> DataSet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            // {
            //     entityType.SetTableName(entityType.DisplayName());
            // }

            //modelBuilder.Entity<Post>().ToTable("Posts");
        }

        public PostContext(DbContextOptions<PostContext> options) : base(options)
        {
        }
    }
}