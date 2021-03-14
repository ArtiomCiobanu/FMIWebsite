using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsWebsiteAPI.Infrastructure.Models.Entities;

namespace NewsWebsiteAPI.DataAccess.EntityConfigurations
{
    public class AccountConfiguration : BaseEntityConfiguration<Account>
    {
        public override void Configure(EntityTypeBuilder<Account> builder)
        {
            base.Configure(builder);

            builder
                .Property(account => account.RoleId)
                .IsRequired();
            builder
                .Property(account => account.FullName)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(account => account.Email)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(account => account.PasswordHash)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}