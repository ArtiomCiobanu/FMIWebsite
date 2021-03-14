using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsWebsiteAPI.Infrastructure.Models.Entities;

namespace NewsWebsiteAPI.DataAccess.EntityConfigurations
{
    public class PostConfiguration : BaseEntityConfiguration<Post>
    {
        public override void Configure(EntityTypeBuilder<Post> builder)
        {
            base.Configure(builder);

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