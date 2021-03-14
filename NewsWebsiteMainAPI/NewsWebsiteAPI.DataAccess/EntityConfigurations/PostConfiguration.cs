using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsWebsiteAPI.Infrastructure.Models.Entities;

namespace NewsWebsiteAPI.DataAccess.EntityConfigurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Content)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}